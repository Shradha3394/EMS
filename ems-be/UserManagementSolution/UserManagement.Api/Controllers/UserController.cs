using Microsoft.AspNetCore.Mvc;
using UserManagement.Api.Filters;
using UserManagement.Common.Dtos;
using UserManagement.Common.Models;

namespace UserManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [Route("create")]
        [HttpPost]
        [ValidateDto]
        public IActionResult Create([FromBody] CreateUserDto userDto)
        {
            // TODO: create User and return response
            return Ok(new BaseResponse<CreateUserResponse>());
        }
    }
}
