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

namespace Application.Features.GithubAddresses.Commands.DeleteGithubAddress
{
    public class DeleteGithubAddressCommandHandler : IRequestHandler<DeleteGithubAddressCommandRequest, DeleteGithubAddressDto>
    {
        private readonly IGithubAddressRepository _githubAddressRepository;
        private readonly IMapper _mapper;

        public DeleteGithubAddressCommandHandler(IGithubAddressRepository githubAddressRepository, IMapper mapper)
        {
            _githubAddressRepository = githubAddressRepository;
            _mapper = mapper;
        }

        public async Task<DeleteGithubAddressDto> Handle(DeleteGithubAddressCommandRequest request, CancellationToken cancellationToken)
        {
            GithubAddress? githubAddress =await _githubAddressRepository.GetAsync(g=>g.Id==request.Id);
            GithubAddress deletedGithubAddress = await _githubAddressRepository.DeleteAsync(githubAddress);
            DeleteGithubAddressDto deleteGithubAddressDto = _mapper.Map<DeleteGithubAddressDto>(deletedGithubAddress);
            return deleteGithubAddressDto;
        }
    }
}
