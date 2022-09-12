using Application.Features.Technologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommandRequest, CreateTechnologyDto>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;

        public CreateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }
        public async Task<CreateTechnologyDto> Handle(CreateTechnologyCommandRequest request, CancellationToken cancellationToken)
        {
            Technology technology = _mapper.Map<Technology>(request);
            Technology createdTechnology= await _technologyRepository.AddAsync(technology);
            CreateTechnologyDto createTechnologyDto =_mapper.Map<CreateTechnologyDto>(createdTechnology);
            return createTechnologyDto;
        }
    }
}
