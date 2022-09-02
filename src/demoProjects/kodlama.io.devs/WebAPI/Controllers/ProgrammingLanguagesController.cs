using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.ListByIdProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Queries.ListProgrammingLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProgrammingLanguageCommandRequest createProgrammingLanguageCommandRequest)
        {
            CreateProgrammingLanguageDto result = await Mediator.Send(createProgrammingLanguageCommandRequest);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] PageRequest pageRequest)
        {
            ListProgrammingLanguageQueryRequest ListProgrammingLanguageQueryRequest = new() { PageRequest = pageRequest };
            ListProgrammingLanguageModel result = await Mediator.Send(ListProgrammingLanguageQueryRequest);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> ListById([FromRoute] ListByIdProgrammingLanguageQueryRequest listByIdProgrammingLanguageQueryRequest)
        {
            ListByIdProgrammingLanguageDto result = await Mediator.Send(listByIdProgrammingLanguageQueryRequest);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingLanguageCommandRequest deleteProgrammingLanguageCommandRequest)
        {
            DeleteProgrammingLanguageDto result = await Mediator.Send(deleteProgrammingLanguageCommandRequest);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommandRequest updateProgrammingLanguageCommandRequest)
        {
            UpdateProgrammingLanguageDto result = await Mediator.Send(updateProgrammingLanguageCommandRequest);
            return Ok(result);
        }
    }
}
