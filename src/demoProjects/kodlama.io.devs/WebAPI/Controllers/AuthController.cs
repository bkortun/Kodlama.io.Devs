using Application.Features.Members.Commands.LoginMember;
using Application.Features.Members.Commands.RegisterMember;
using Core.Security.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
       [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginMemberCommandRequest loginMemberCommandRequest)
        {
            AccessToken result =await Mediator.Send(loginMemberCommandRequest);
            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterMemberCommandRequest registerMemberCommandRequest)
        {
            AccessToken result = await Mediator.Send(registerMemberCommandRequest);
            return Created("",result);
        }
    }
}
