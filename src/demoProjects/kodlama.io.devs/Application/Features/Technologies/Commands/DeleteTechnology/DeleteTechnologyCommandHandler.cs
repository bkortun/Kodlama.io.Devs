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

namespace Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommandRequest, DeleteTechnologyDto>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;

        public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }
        public async Task<DeleteTechnologyDto> Handle(DeleteTechnologyCommandRequest request, CancellationToken cancellationToken)
        {
            Technology? technology =await  _technologyRepository.GetAsync(t=>t.Id==request.Id);
            Technology deletedTechnology = await _technologyRepository.DeleteAsync(technology);
            DeleteTechnologyDto deleteTechnologyDto = _mapper.Map<DeleteTechnologyDto>(deletedTechnology);
            return deleteTechnologyDto;
        }
    }
}
