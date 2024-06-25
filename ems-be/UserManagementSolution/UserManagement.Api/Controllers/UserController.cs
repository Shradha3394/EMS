using Microsoft.AspNetCore.Mvc;
using UserManagement.Common.Dtos;
using UserManagement.Common.Models;

namespace UserManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [Route("create")]
        public IActionResult Create([FromBody] CreateUserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new BaseResponse<CreateUserResponse>(string.Join(";", errors)));
            }
            // TODO: create User and return response
            return Ok();
        }
    }
}
