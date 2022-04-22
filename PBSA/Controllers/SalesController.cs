using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PBSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        [HttpGet]
        public async Task<List<Sale>> GetSales(int id)
        {
            return null;
        }
        [HttpPost]
        public async Task<int> createSales(Sale sale)
        {
            return 0;
        }
    }
}
