using PBSA.Models.DB;
using System.Collections.Generic;

namespace PBSA.Interface
{
    public interface IAddressService
    {
        int GetAddressTypeId(string type);
        List<Address> GetAddressById(int addressId);
    }
}
