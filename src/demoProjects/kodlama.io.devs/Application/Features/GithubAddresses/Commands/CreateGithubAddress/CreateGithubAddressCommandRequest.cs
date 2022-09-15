using Application.Features.GithubAddresses.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Commands.CreateGithubAddress
{
    public class CreateGithubAddressCommandRequest:IRequest<CreateGithubAddressDto>
    {
        public int MemberId { get; set; }
        public string Address { get; set; }
    }
}
