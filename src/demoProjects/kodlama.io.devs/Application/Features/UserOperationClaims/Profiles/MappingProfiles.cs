using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserOperationClaim, ListUserOperationClaimDto>().ForMember(u => u.Email, opt => opt.MapFrom(p => p.User.Email)).ForMember(u=>u.Name,opt=>opt.MapFrom(u=>u.OperationClaim.Name)).ReverseMap();
            CreateMap<ListUserOperationClaimModel,IPaginate<UserOperationClaim>>().ReverseMap();
           
        }
    }
}
