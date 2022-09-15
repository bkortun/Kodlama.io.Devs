using Application.Features.GithubAddresses.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Queries.ListGithubAddress
{
    public class ListGithubAddressQueryRequest:IRequest<ListGithubAddressModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
