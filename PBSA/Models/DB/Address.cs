using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PBSA.Models.DB
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public int AddressTypeId { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual AddressType AddressType { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
