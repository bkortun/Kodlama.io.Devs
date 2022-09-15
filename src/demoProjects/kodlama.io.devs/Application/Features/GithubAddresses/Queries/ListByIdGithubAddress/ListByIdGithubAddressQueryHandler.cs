using Application.Features.GithubAddresses.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Queries.ListByIdGithubAddress
{
    public class ListByIdGithubAddressQueryHandler : IRequestHandler<ListByIdGithubAddressQueryRequest, ListByIdGithubAddressDto>
    {
        private readonly IGithubAddressRepository _githubAddressRepository;
        private readonly IMapper _mapper;

        public ListByIdGithubAddressQueryHandler(IGithubAddressRepository githubAddressRepository, IMapper mapper)
        {
            _githubAddressRepository = githubAddressRepository;
            _mapper = mapper;
        }

        public async Task<ListByIdGithubAddressDto> Handle(ListByIdGithubAddressQueryRequest request, CancellationToken cancellationToken)
        {
            GithubAddress githubAddress = await _githubAddressRepository.Query().Include(g=>g.Member).FirstOrDefaultAsync(g=>g.Id==request.Id);
            ListByIdGithubAddressDto listByIdGithubAddressDto = _mapper.Map<ListByIdGithubAddressDto>(githubAddress);
            return listByIdGithubAddressDto;
        }
    }
}
