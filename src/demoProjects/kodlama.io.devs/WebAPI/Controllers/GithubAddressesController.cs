using Application.Features.GithubAddresses.Commands.CreateGithubAddress;
using Application.Features.GithubAddresses.Commands.DeleteGithubAddress;
using Application.Features.GithubAddresses.Commands.UpdateGithubAddress;
using Application.Features.GithubAddresses.Dtos;
using Application.Features.GithubAddresses.Models;
using Application.Features.GithubAddresses.Queries.ListByIdGithubAddress;
using Application.Features.GithubAddresses.Queries.ListGithubAddress;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubAddressesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGithubAddressCommandRequest createGithubAddressCommandRequest)
        {
            CreateGithubAddressDto result = await Mediator.Send(createGithubAddressCommandRequest);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] PageRequest pageRequest)
        {
            ListGithubAddressQueryRequest listGithubAddressQueryRequest = new() { PageRequest = pageRequest };
            ListGithubAddressModel result = await Mediator.Send(listGithubAddressQueryRequest);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> ListById([FromRoute] ListByIdGithubAddressQueryRequest listByIdGithubAddressQueryRequest)
        {
            ListByIdGithubAddressDto result = await Mediator.Send(listByIdGithubAddressQueryRequest);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteGithubAddressCommandRequest deleteGithubAddressCommandRequest)
        {
            DeleteGithubAddressDto result = await Mediator.Send(deleteGithubAddressCommandRequest);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGithubAddressCommandRequest updateGithubAddressCommandRequest)
        {
            UpdateGithubAddressDto result = await Mediator.Send(updateGithubAddressCommandRequest);
            return Ok(result);
        }
    }
}
