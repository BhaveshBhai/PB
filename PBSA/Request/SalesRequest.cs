using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBSA.Request
{
    public class SalesRequest
    {
       public List<AddressTypeRequest> Address { get; set; } 
        public CustomerRequest Customer { get; set; }
        public List<ProductRequest> Product { get; set; }
    }
}
