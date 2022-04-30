using PBSA.Models.DB;

namespace PBSA.Interface
{
    public interface ICustomerService
    {
        Customer GetCustomerId(int customerId);
        Customer GetCustomerByEmail(string email);
    }
}
