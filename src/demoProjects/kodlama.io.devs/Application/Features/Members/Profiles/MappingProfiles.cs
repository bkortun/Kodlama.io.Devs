using Application.Features.Members.Commands.RegisterMember;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Members.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Member,RegisterMemberCommandRequest>().ReverseMap();
        }
    }
}
