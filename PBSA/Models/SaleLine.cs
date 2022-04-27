using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PBSA.Models
{
    public partial class SaleLine
    {
        public int SaleLineId { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotalAmount { get; set; }
        public decimal SubTotalTax { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
