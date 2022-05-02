using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PBSA.Interface;
using PBSA.Models;
using System.Collections.Generic;

namespace PBSA.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJwtAuthService _jwtAuthService;
        public UserController (IJwtAuthService jwtAuthService)
        {
            _jwtAuthService = jwtAuthService;
        }
        [AllowAnonymous]
        [HttpPost("authorization")]
        public IActionResult Authorization([FromBody] UserCredentialModel userCredential)
        {
            var token = _jwtAuthService.Authorization(userCredential.UserName, userCredential.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
