using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.DeleteTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using Application.Features.Technologies.Queries.ListTechnology;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> List([FromQuery] PageRequest pageRequest)
        {
            ListTechnologyQueryRequest listTechnologyQueryRequest = new(){PageRequest=pageRequest };
            ListTechnologyModel result= await Mediator.Send(listTechnologyQueryRequest);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTechnologyCommandRequest createTechnologyCommandRequest)
        {
            CreateTechnologyDto result = await Mediator.Send(createTechnologyCommandRequest);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommandRequest updateTechnologyCommandRequest)
        {
            UpdateTechnologyDto result = await Mediator.Send(updateTechnologyCommandRequest);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteTechnologyCommandRequest deleteTechnologyCommandRequest)
        {
            DeleteTechnologyDto result = await Mediator.Send(deleteTechnologyCommandRequest);
            return Ok(result);
        }
    }
}
