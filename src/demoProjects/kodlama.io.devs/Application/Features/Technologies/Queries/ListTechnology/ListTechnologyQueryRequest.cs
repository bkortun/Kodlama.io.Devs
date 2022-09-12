using Application.Features.Technologies.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Queries.ListTechnology
{
    public class ListTechnologyQueryRequest:IRequest<ListTechnologyModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
