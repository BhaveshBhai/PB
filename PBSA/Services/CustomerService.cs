using PBSA.Interface;
using PBSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBSA.Services
{
    public class CustomerService : ICustomerService
    {
        public Customer getCustomerId(int customerId)
        {
            using (var db = new PBSAContext())
            {
                return db.Customer.Where(x => x.CustomerId == customerId).FirstOrDefault();
            }
        }
    }
}
