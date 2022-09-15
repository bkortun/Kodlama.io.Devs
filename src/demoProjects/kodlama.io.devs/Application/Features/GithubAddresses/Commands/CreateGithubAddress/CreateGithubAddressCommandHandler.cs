using Application.Features.GithubAddresses.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Commands.CreateGithubAddress
{
    public class CreateGithubAddressCommandHandler : IRequestHandler<CreateGithubAddressCommandRequest, CreateGithubAddressDto>
    {
        private readonly IGithubAddressRepository _githubAddressRepository;
        private readonly IMapper _mapper;

        public CreateGithubAddressCommandHandler(IGithubAddressRepository githubAddressRepository, IMapper mapper)
        {
            _githubAddressRepository = githubAddressRepository;
            _mapper = mapper;
        }

        public async Task<CreateGithubAddressDto> Handle(CreateGithubAddressCommandRequest request, CancellationToken cancellationToken)
        {
            GithubAddress githubAddress = _mapper.Map<GithubAddress>(request);
            GithubAddress addedGithubAddress = await _githubAddressRepository.AddAsync(githubAddress);
            CreateGithubAddressDto createGithubAddressDto = _mapper.Map<CreateGithubAddressDto>(addedGithubAddress);
            return createGithubAddressDto;
        }
    }
}
