using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {

        public class User{
            public string name { get; set; }
            public string email { get; set; }
            public string password { get; set; }
        }

        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            return Ok(user);
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            return Ok(user);
        }

        [HttpGet("users")]
        public IActionResult Users(User user)
        {
            return Ok(user);
        }
    }
}
