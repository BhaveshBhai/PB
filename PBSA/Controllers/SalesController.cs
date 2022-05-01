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
                var result = new NotFoundObjectResult(new { message = "404 Not Found", currentDate = DateTime.Now });
                return result;
            }
            else
            {
                var salesResponse = await _salesService.GetSaleRespone(sale);
                if (salesResponse == null)
                {
                    var result = new NotFoundObjectResult(new { message = "404 Not Found", currentDate = DateTime.Now });
                    return result;
                }
                return Ok(salesResponse);
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
