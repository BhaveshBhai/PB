using PBSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBSA.Request
{
    public class SalesRequest
    {
       public List<AddressModel> Address { get; set; } 
        public CustomerModel Customer { get; set; }
        public List<ProductRequest> Product { get; set; }
    }
}
