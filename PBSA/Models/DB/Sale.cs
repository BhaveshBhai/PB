using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PBSA.Models.DB
{
    public partial class Sale
    {
        public int SaleId { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalTax { get; set; }
        public string SaleLineIds { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
