using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PBSA.Request
{
    public class ProductRequest
    {
        [Required]
        public string Title{get;set;}
        [Required]
        public string Code { get; set; }
        [Required]
        public decimal Weight { get; set; }
        [Required]
        public decimal PriceAmount { get; set; }
        [Required]
        public decimal PriceTax { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
