using PBSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBSA.Interface
{
    public interface IAddressService
    {
        int GetAddressTypeId(string type);
        List<Address> GetAddressById(int addressId);
    }
}
