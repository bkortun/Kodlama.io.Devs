using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
      /*  [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserDto result =await Mediator.Send(loginUserCommandRequest);
            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommandRequest registerUserCommandRequest)
        {
            RegisterUserDto result = await Mediator.Send(registerUserCommandRequest);
            return Ok(result);
        }*/
    }
}
