using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBSA.Response
{
    public class SaleResponse
    {
        public decimal TotalAmount { get; set; }
        public decimal TotalTax { get; set; }
        public int CustomerId { get; set; }
        public string SaleLineIds { get; set; }
    }
}
