using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.ListProgrammingLanguage
{
    public class ListProgrammingLanguageQueryHandler : IRequestHandler<ListProgrammingLanguageQueryRequest, ListProgrammingLanguageModel>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;

        public ListProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
        }

        public async Task<ListProgrammingLanguageModel> Handle(ListProgrammingLanguageQueryRequest request, CancellationToken cancellationToken)
        {
           IPaginate<ProgrammingLanguage> programmingLanguages = await _programmingLanguageRepository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize);
            ListProgrammingLanguageModel listProgrammingLanguageModel = _mapper.Map<ListProgrammingLanguageModel>(programmingLanguages);
            return listProgrammingLanguageModel;
        }
    }
}
