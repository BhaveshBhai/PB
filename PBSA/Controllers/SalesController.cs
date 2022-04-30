using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PBSA.Interface;
using PBSA.Request;
using PBSA.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace PBSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        public readonly ISalesService _salesService;
        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }
        [HttpGet]
        [ResponseType(typeof(SalesResponse))]
        public async Task<IActionResult> GetAsync(int id)
        {
            var sale = await _salesService.GetSaleById(id);
            if (sale == null)
            {
                return NotFound();
            }
            else
            {
                var result = await _salesService.GetSaleRespone(sale);
                return Ok(result);
            }
        }
        [HttpPost]
        [ResponseType(typeof(CreateSaleResponse))]
        public async Task<IActionResult> Post([FromBody] SalesRequest salesRequest)
        {
            if (ModelState.IsValid)
            {   
                var result = await _salesService.CreateSale(salesRequest);
                if (result > 0)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
