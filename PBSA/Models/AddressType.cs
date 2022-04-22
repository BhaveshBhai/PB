using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PBSA.Models
{
    public partial class AddressType
    {
        public AddressType()
        {
            Address = new HashSet<Address>();
            Sale = new HashSet<Sale>();
        }

        public int AddressTypeId { get; set; }
        public string AddresType { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Sale> Sale { get; set; }
    }
}
