using PBSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBSA.Response
{
    public class SalesResponse
    {
        public List<ProductResponse> Products { get; set; }
        public CustomerModel Customer { get; set; }
        public List<AddressModel> Address { get; set; }
        public SaleResponse Sale { get; set; }
    }
    
}
