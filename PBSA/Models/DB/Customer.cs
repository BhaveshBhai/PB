using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PBSA.Models.DB
{
    public partial class Customer
    {
        public Customer()
        {
            Address = new HashSet<Address>();
            Sale = new HashSet<Sale>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Sale> Sale { get; set; }
    }
}
