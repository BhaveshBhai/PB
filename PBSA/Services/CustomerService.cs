using PBSA.Interface;
using PBSA.Models.DB;
using System.Linq;

namespace PBSA.Services
{
    public class CustomerService : ICustomerService
    {
        public bool GetCustomerByEmail(string email)
        {
            using (var db = new PBSAContext())
            {
                return db.Customer.Where(x => x.Email == email).Count() > 0 ? true : false;
            }
        }

        public Customer GetCustomerId(int customerId)
        {
            using (var db = new PBSAContext())
            {
                return db.Customer.Where(x => x.CustomerId == customerId).FirstOrDefault();
            }
        }
    }
}
