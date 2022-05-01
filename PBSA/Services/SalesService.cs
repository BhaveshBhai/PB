using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PBSA.Interface;
using PBSA.Models;
using PBSA.Models.DB;
using PBSA.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBSA.Services
{
    public class SalesService : ISalesService
    {
        private readonly IMapper _mapper;
        private readonly IAddressService _addressService;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly ILogger _logger;
        public SalesService(
            IMapper mapper, IAddressService addressService,
            ICustomerService customerService,
            IProductService productService,
            ILogger logger)
        {
            _mapper = mapper;
            _addressService = addressService;
            _customerService = customerService;
            _productService = productService;
            _logger = logger;
        }
        public Task<int> CreateSale(SalesRequest salesRequest)
        {
            _logger.LogInformation($"Create sale service with request:{salesRequest}");
            decimal totalAmount = 0.0m;
            decimal totalTax = 0.0m;
            List<string> salelineIds = new List<string>();
            Sale sale = new Sale();
            using (var context = new PBSAContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //Check customer already there or not
                        // Email address is uniq.
                        var customer = _customerService.GetCustomerByEmail(salesRequest.Customer.Email);
                        if (customer == null)
                        {
                            customer = _mapper.Map<Customer>(salesRequest.Customer);
                            customer.UserId = 1;
                            context.Customer.Add(customer);
                            context.SaveChanges();
                        }

                        foreach (var item in salesRequest.Address)
                        {
                            var address = _mapper.Map<Address>(item);
                            address.AddressTypeId = _addressService.GetAddressTypeId(item.Type);
                            address.CustomerId = customer.CustomerId;

                            //Upodate address based on customerId and AddressTypeId
                            var updateAddress = _addressService.GetAddressByCustomer(address.CustomerId, address.AddressTypeId);
                            if (updateAddress != null)
                            {
                                address.AddressId = updateAddress.AddressId;
                                context.Address.Update(address);
                            }
                            else
                            {
                                context.Address.Add(address);
                            }
                            context.SaveChanges();
                        }

                        foreach (var productRequest in salesRequest.Product)
                        {
                            //If product is already there then not allow to insert dublicate product
                            //Here Product code is uniq.
                            var product = _productService.GetProductByCode(productRequest.Code);
                            if (product == null)
                            {
                                product = _mapper.Map<Product>(productRequest);
                                context.Product.Add(product);
                                context.SaveChanges();
                            }

                            SaleLine saleLine = new SaleLine();
                            saleLine.ProductId = product.ProductId;
                            saleLine.Quantity = productRequest.Quantity;
                            saleLine.SubTotalAmount = productRequest.PriceAmount * productRequest.Quantity;
                            saleLine.SubTotalTax = productRequest.PriceTax * productRequest.Quantity;

                            context.SaleLine.Add(saleLine);
                            context.SaveChanges();

                            salelineIds.Add(saleLine.SaleLineId.ToString());

                            totalAmount += saleLine.SubTotalAmount;
                            totalTax += saleLine.SubTotalTax;
                        }

                        sale.CustomerId = customer.CustomerId;
                        sale.SaleLineIds = string.Join(",", salelineIds);
                        sale.TotalAmount = totalAmount;
                        sale.TotalTax = totalTax;

                        context.Sale.Add(sale);
                        context.SaveChanges();

                        transaction.Commit();
                        return Task.FromResult(sale.SaleId);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        _logger.LogError($"Error in create sales with message: {ex.Message}");
                        return Task.FromResult(sale.SaleId);
                    }
                }
            }
        }
        public Task<Sale> GetSaleById(int id)
        {
            using var db = new PBSAContext();
            return Task.FromResult(db.Sale.Where(x => x.SaleId == id).Include("Customer").FirstOrDefault());
        }
        public async Task<Response.SalesResponse> GetSaleRespone(Sale sale)
        {
            _logger.LogInformation($"GetSale method call with Sale :{sale}");
            Response.SalesResponse saleResponse = new Response.SalesResponse();
            try
            {
                saleResponse.Sale = _mapper.Map<Response.SaleResponse>(sale);
                var customer = _customerService.GetCustomerId(saleResponse.Sale.CustomerId);
                saleResponse.Customer = customer != null ? _mapper.Map<CustomerModel>(customer) : null;
                //Linq query 
                var addresses = (from address1 in _addressService.GetAddressById(Convert.ToInt32(saleResponse.Sale.CustomerId))
                                 select new AddressModel
                                 {
                                     PostCode = address1.PostCode,
                                     Street = address1.Street,
                                     Type = address1.AddressType.AddresType
                                 }).ToList();

                List<Response.ProductResponse> products = new List<Response.ProductResponse>();
                // I already use lebmda query so here I use foreach loop
                foreach (var item in saleResponse.Sale.SaleLineIds.Split(","))
                {
                    var saleLine = await GetSaleLineById(Convert.ToInt32(item));
                    var productResponse = _mapper.Map<Response.ProductResponse>(saleLine.Product);
                    productResponse.SubTotal = saleLine.SubTotalAmount;
                    productResponse.SubTotalTax = saleLine.SubTotalTax;
                    productResponse.Quantity = saleLine.Quantity;
                    products.Add(productResponse);
                };
                saleResponse.Address = addresses;
                saleResponse.Products = products;

                return await Task.FromResult(saleResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in get sales record with message: {ex.Message}");
                return await Task.FromResult(saleResponse);
            }

        }
        public Task<SaleLine> GetSaleLineById(int saleLineId)
        {
            using var db = new PBSAContext();
            return Task.FromResult(db.SaleLine.Where(x => x.SaleLineId == saleLineId).Include("Product").FirstOrDefault());
        }
    }
}
