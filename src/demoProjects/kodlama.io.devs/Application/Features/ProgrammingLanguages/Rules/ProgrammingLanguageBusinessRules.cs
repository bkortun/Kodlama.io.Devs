using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageCanNotBeDuplicatedWhenInserted(string name)
        {
            ProgrammingLanguage? programmingLanguage= await _programmingLanguageRepository.GetAsync(p => p.Name == name);
            if (programmingLanguage != null) throw new BusinessException("Programming language name exists.");
        }

        public void ProgrammingLanguageShouldExistWhenRequired(ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException("Requested programming language does not exist");
        }
    }
}
