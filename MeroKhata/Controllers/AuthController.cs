using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroKhata.Controllers
{
    [Route("")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("Success");
        }
    }
}
