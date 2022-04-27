using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PBSA.Interface;
using PBSA.Models;
using PBSA.Request;
using PBSA.Response;
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
        public SalesService(
            IMapper mapper, IAddressService addressService, ICustomerService customerService, IProductService productService)
        {
            _mapper = mapper;
            _addressService = addressService;
            _customerService = customerService;
            _productService = productService;
        }
        public Task<int> CreateSale(SalesRequest salesRequest)
        {
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
                        var customer = _mapper.Map<Models.Customer>(salesRequest.Customer);
                        //customer.CustomerId = 1;
                        context.Customer.Add(customer);
                        context.SaveChanges();

                        foreach (var item in salesRequest.Address)
                        {
                            var address = _mapper.Map<Models.Address>(item.AddressRequest);
                            address.AddressTypeId = _addressService.GetAddressTypeId(item.Type);
                            address.CustomerId = customer.CustomerId;
                            context.Address.Add(address);
                            context.SaveChanges();
                        }

                        foreach (var productRequest in salesRequest.Product)
                        {
                            var product = _mapper.Map<Models.Product>(productRequest);
                            context.Product.Add(product);
                            context.SaveChanges();

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
                        return Task.FromResult(sale.SaleId);
                    }
                }
            }
        }
        public Task<Models.Sale> GetSaleById(int id)
        {
            using (var db = new PBSAContext())
            {
                return Task.FromResult(db.Sale.Where(x => x.SaleId == id).Include("Customer").FirstOrDefault());
            }
        }
        public Task<SaleResponse> GetSaleRespone(Models.Sale sale)
        {
            try
            {
                SaleResponse saleResponse = new SaleResponse();
                saleResponse.Sale = _mapper.Map<Sales>(sale);
                saleResponse.Customer = _mapper.Map<Response.Customer>(_customerService.getCustomerId(saleResponse.Sale.CustomerId));
                List<Response.Address> addresses = new List<Response.Address>();
                var address = _addressService.GetAddressById(Convert.ToInt32(saleResponse.Sale.CustomerId));
                foreach (var item in address)
                {
                    Response.Address ad = new Response.Address();
                    ad = _mapper.Map<Response.Address>(item);
                    ad.Type = item.AddressType.AddresType;
                    addresses.Add(ad);
                }
                List<Response.Product> products = new List<Response.Product>();
                foreach (var item in saleResponse.Sale.SaleLineIds.Split(","))
                {
                    var saleLine = GetSaleLineById(Convert.ToInt32(item)).Result;
                    var p = _mapper.Map<Response.Product>(saleLine.Product);
                    p.SubTotal = saleLine.SubTotalAmount;
                    p.SubTotalTax = saleLine.SubTotalTax;
                    p.Quantity = saleLine.Quantity;
                    products.Add(p);
                };
                saleResponse.Address = addresses;
                saleResponse.Products = products;
                return Task.FromResult(saleResponse);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        public Task<SaleLine> GetSaleLineById(int saleLineId)
        {
            using (var db = new PBSAContext())
            {
                return Task.FromResult(db.SaleLine.Where(x => x.SaleLineId == saleLineId).Include("Product").FirstOrDefault());
            }
        }
    }
}
