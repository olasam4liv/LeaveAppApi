using LeaveAppApi.DTOs;
using LeaveAppApi.Models;
using LeaveAppApi.Services.UserService;
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
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;

        }

        [Route("User")]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetUserDto>>>> GetAllUser()
        {
            var response = await _userService.GetAllUsers();
            if (response == null)
            {
                return NotFound(response.Message = "No record found");
            }
            else if (response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [Route("User")]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<IEnumerable<User>>>> CreateUser(User newUser)
        {

            var result = await _userService.CreateUser(newUser);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }
    }
}
