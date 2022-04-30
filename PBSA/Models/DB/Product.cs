using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PBSA.Models.DB
{
    public partial class Product
    {
        public Product()
        {
            SaleLine = new HashSet<SaleLine>();
        }

        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public decimal Weight { get; set; }
        public decimal PriceAmount { get; set; }
        public decimal PriceTax { get; set; }

        public virtual ICollection<SaleLine> SaleLine { get; set; }
    }
}
