using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            //CreateProgrammingLanguageCommandRequest->ProgrammingLanguage->CreateProgrammingLanguageDto
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommandRequest>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageDto>().ReverseMap();

            //PageRequest=>IPaginate<ProgrammingLanguage>->ListProgrammingLanguageModel=>ListProgrammingLanguageDto->ProgrammingLanguage
            CreateMap<IPaginate<ProgrammingLanguage>, ListProgrammingLanguageModel>().ReverseMap();
            CreateMap<ProgrammingLanguage, ListProgrammingLanguageDto>().ReverseMap();

            //ListByIdProgrammingLanguageQueryRequest=>ProgrammingLanguage->ListByIdProgrammingLanguageDto
            CreateMap<ProgrammingLanguage, ListByIdProgrammingLanguageDto>().ReverseMap();

            //DeleteProgrammingLanguageCommandRequest=>ProgrammingLanguage->DeleteProgrammingLanguageDto
            CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageDto>().ReverseMap();

            //UpdateProgrammingLanguageCommandRequest->ProgrammingLanguage->DeleteProgrammingLanguageDto
            CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommandRequest>().ReverseMap();

        }
    }
}
