using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBSA.Response
{
    public class ProductResponse
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
}
