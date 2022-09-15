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

namespace Application.Features.GithubAddresses.Commands.UpdateGithubAddress
{
    public class UpdateGithubAddressCommandHandler : IRequestHandler<UpdateGithubAddressCommandRequest, UpdateGithubAddressDto>
    {
        private readonly IGithubAddressRepository _githubAddressRepository;
        private readonly IMapper _mapper;

        public UpdateGithubAddressCommandHandler(IGithubAddressRepository githubAddressRepository, IMapper mapper)
        {
            _githubAddressRepository = githubAddressRepository;
            _mapper = mapper;
        }

        public async Task<UpdateGithubAddressDto> Handle(UpdateGithubAddressCommandRequest request, CancellationToken cancellationToken)
        {
            GithubAddress githubAddress = _mapper.Map<GithubAddress>(request);
            GithubAddress updatedGithubAddress=await _githubAddressRepository.UpdateAsync(githubAddress);
            UpdateGithubAddressDto updateGithubAddressDto = _mapper.Map<UpdateGithubAddressDto>(updatedGithubAddress);
            return updateGithubAddressDto;
        }
    }
}
