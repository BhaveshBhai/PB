using PBSA.Models.DB;

namespace PBSA.Interface
{
    public interface ICustomerService
    {
        Customer GetCustomerId(int customerId);
        bool GetCustomerByEmail(string email);
    }
}
