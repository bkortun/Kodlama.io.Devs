using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            //List
            CreateMap<Technology,ListTechnologyDto>().ForMember(c=>c.ProgrammingLanguageName,opt=>opt.MapFrom(e=>e.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<IPaginate<Technology>,ListTechnologyModel>().ReverseMap();

            //Create
            CreateMap<Technology,CreateTechnologyCommandRequest>().ReverseMap();
            CreateMap<Technology,CreateTechnologyDto>().ReverseMap();

            //Delete
            CreateMap<Technology, DeleteTechnologyDto>().ReverseMap();

            //Update
            CreateMap<Technology, UpdateTechnologyDto>().ReverseMap();
            CreateMap<Technology, UpdateTechnologyCommandRequest>().ReverseMap();
        }
    }
}