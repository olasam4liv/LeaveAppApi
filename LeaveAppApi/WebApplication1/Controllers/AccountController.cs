using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAppApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [Route("User")]
        [HttpGet]
        public async Task<ActionResult> GetAllUser()
        {
            
            return Ok( );
        }

    }
}
