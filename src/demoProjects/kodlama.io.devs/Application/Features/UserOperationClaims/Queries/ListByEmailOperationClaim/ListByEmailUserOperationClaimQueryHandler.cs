using Application.Features.UserOperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Queries.ListByEmailOperationClaim
{
    public class ListByEmailUserOperationClaimQueryHandler : IRequestHandler<ListByEmailUserOperationClaimQueryRequest, ListByEmailUserOperationClaimModel>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public ListByEmailUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<ListByEmailUserOperationClaimModel> Handle(ListByEmailUserOperationClaimQueryRequest request, CancellationToken cancellationToken)
        {
           IPaginate<UserOperationClaim> userOperationClaims= await _userOperationClaimRepository.GetListAsync(predicate:u=>u.User.Email==request.Email,include:u=>u.Include(u=>u.OperationClaim));
            ListByEmailUserOperationClaimModel listByEmailOperationClaimModel = _mapper.Map<ListByEmailUserOperationClaimModel>(userOperationClaims);
            return listByEmailOperationClaimModel;
        }
    }
}
