using Application.Features.UserOperationClaims.Commands.CreateOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Queries.ListByEmailOperationClaim;
using Application.Features.UserOperationClaims.Queries.ListUserOperationClaim;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateUserOperationClaimCommandRequest createUserOperationClaimCommandRequest)
        {
            CreateUserOperationClaimDto result = await Mediator.Send(createUserOperationClaimCommandRequest);
            return Created("",result);
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] ListUserOperationClaimQueryRequest listUserOperationClaimCommandRequest)
        {
            ListUserOperationClaimModel result = await Mediator.Send(listUserOperationClaimCommandRequest);
            return Ok(result);
        }

        [HttpGet("ListByEmail")]
        public async Task<IActionResult> ListByEmail([FromQuery] ListByEmailUserOperationClaimQueryRequest listByEmailUserOperationClaimCommandRequest)
        {
            ListByEmailUserOperationClaimModel result = await Mediator.Send(listByEmailUserOperationClaimCommandRequest);
            return Ok(result);
        }
    }
}
