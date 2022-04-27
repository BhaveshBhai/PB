using Microsoft.EntityFrameworkCore;
using PBSA.Interface;
using PBSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBSA.Services
{
    public class AddressService : IAddressService
    {
        public int GetAddressTypeId(string type)
        {
            using (var context = new PBSAContext())
            {
                return (int)(context.AddressType.Where(x => x.AddresType == type).FirstOrDefault()?.AddressTypeId);
            }
        }
        public List<Address> GetAddressById(int addressId)
        {
            using (var context = new PBSAContext())
            {
                return context.Address.Where(x => x.AddressId == addressId).Include("AddressType").ToList();
            }
        }
    }
}
