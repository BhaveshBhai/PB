using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PBSA.Request
{
    public class SaleRequest
    {
        [Required]
        public decimal TotalAmount { get; set; }
        [Required]
        public decimal TotalTax { get; set; }
    }
}
