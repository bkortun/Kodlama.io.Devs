using Application.Features.GithubAddresses.Commands.CreateGithubAddress;
using Application.Features.GithubAddresses.Commands.UpdateGithubAddress;
using Application.Features.GithubAddresses.Dtos;
using Application.Features.GithubAddresses.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<GithubAddress,CreateGithubAddressDto>().ReverseMap();
            CreateMap<CreateGithubAddressCommandRequest, GithubAddress>().ReverseMap();

            CreateMap<GithubAddress,UpdateGithubAddressDto>().ReverseMap();
            CreateMap<UpdateGithubAddressCommandRequest, GithubAddress>().ReverseMap();

            CreateMap<GithubAddress,DeleteGithubAddressDto>().ReverseMap();

            CreateMap<GithubAddress,ListGithubAddressDto>().ReverseMap();
            CreateMap<IPaginate<GithubAddress>,ListGithubAddressModel>().ReverseMap();

            //CreateMap<GithubAddress,ListByIdGithubAddressDto>().ForMember(g=>g.Email,opt=>opt.MapFrom(m=>m.Member.Email)).ReverseMap();
        }
    }
}
