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

namespace Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommandRequest, UpdateTechnologyDto>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;

        public UpdateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }
        public async Task<UpdateTechnologyDto> Handle(UpdateTechnologyCommandRequest request, CancellationToken cancellationToken)
        {
            Technology technology = _mapper.Map<Technology>(request);
            Technology updatedTechnology = await _technologyRepository.UpdateAsync(technology);
            UpdateTechnologyDto updateTechnologyDto = _mapper.Map<UpdateTechnologyDto>(updatedTechnology);
            return updateTechnologyDto;
        }
    }
}
