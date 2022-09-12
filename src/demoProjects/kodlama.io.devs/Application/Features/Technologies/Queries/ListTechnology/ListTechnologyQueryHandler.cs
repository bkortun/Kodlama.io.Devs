using Application.Features.Technologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Queries.ListTechnology
{
    public class ListTechnologyQueryHandler : IRequestHandler<ListTechnologyQueryRequest, ListTechnologyModel>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;

        public ListTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }

        public async Task<ListTechnologyModel> Handle(ListTechnologyQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<Technology> technologies = await _technologyRepository.GetListAsync(include: t => t.Include(e => e.ProgrammingLanguage), index: request.PageRequest.Page, size: request.PageRequest.PageSize);
            ListTechnologyModel listTechnologyModel = _mapper.Map<ListTechnologyModel>(technologies);
            return listTechnologyModel;
        }
    }
}
