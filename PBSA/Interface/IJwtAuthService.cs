using PBSA.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBSA.Interface
{
    public interface IJwtAuthService
    {
       string Authorization(string username, string password);
    }
}
