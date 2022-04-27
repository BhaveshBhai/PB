using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PBSA.Request
{
    public class SaleLineRequest
    {
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public decimal SubTotalAmount { get; set; }
        [Required]
        public decimal SubTotalTax { get; set; }
    }
}
