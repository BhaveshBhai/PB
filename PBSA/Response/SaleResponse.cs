using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBSA.Response
{
    public class SaleResponse
    {
        public List<Product> Products { get; set; }
        public Customer Customer { get; set; }
        public List<Address> Address { get; set; }
        public Sales Sale { get; set; }
    }
    public class Product
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public decimal Weight { get; set; }
        public decimal PriceAmount { get; set; }
        public decimal PriceTax { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public decimal SubTotalTax { get; set; }
    }
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
    public class Address
    {
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string Type { get; set; }
    }
    public class Sales
    {
        public decimal TotalAmount { get; set; }
        public decimal TotalTax { get; set; }
        public int CustomerId { get; set; }
        public string SaleLineIds { get; set; }
    }
}
