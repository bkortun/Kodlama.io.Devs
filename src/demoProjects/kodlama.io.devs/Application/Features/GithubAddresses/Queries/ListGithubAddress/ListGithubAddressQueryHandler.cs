using Application.Features.GithubAddresses.Models;
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

namespace Application.Features.GithubAddresses.Queries.ListGithubAddress
{
    public class ListGithubAddressQueryHandler : IRequestHandler<ListGithubAddressQueryRequest, ListGithubAddressModel>
    {
        private readonly IGithubAddressRepository _githubAddressRepository;
        private readonly IMapper _mapper;

        public ListGithubAddressQueryHandler(IGithubAddressRepository githubAddressRepository, IMapper mapper)
        {
            _githubAddressRepository = githubAddressRepository;
            _mapper = mapper;
        }

        public async Task<ListGithubAddressModel> Handle(ListGithubAddressQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<GithubAddress> githubAddress = await _githubAddressRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
            ListGithubAddressModel listGithubAddressModel = _mapper.Map<ListGithubAddressModel>(githubAddress);
            return listGithubAddressModel;
        }
    }
}
