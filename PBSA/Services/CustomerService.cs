using PBSA.Interface;
using PBSA.Models.DB;
using System.Linq;

namespace PBSA.Services
{
    public class CustomerService : ICustomerService
    {
        public Customer GetCustomerByEmail(string email)
        {
            using var db = new PBSAContext();
            return db.Customer.Where(x => x.Email == email).FirstOrDefault();
        }

        public Customer GetCustomerId(int customerId)
        {
            using var db = new PBSAContext();
            return db.Customer.Where(x => x.CustomerId == customerId).FirstOrDefault();
        }
    }
}
