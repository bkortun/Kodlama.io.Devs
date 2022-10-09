using Application.Features.UserOperationClaims.Dtos;
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

namespace Application.Features.UserOperationClaims.Queries.ListUserOperationClaim
{
    public class ListUserOperationClaimQueryHandler : IRequestHandler<ListUserOperationClaimQueryRequest, ListUserOperationClaimModel>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public ListUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<ListUserOperationClaimModel> Handle(ListUserOperationClaimQueryRequest request, CancellationToken cancellationToken)
        {
           IPaginate<UserOperationClaim> userOperationClaim=await _userOperationClaimRepository.GetListAsync(include: u => u.Include(u => u.OperationClaim).Include(u => u.User),index:request.PageRequest.Page,size:request.PageRequest.PageSize);
           ListUserOperationClaimModel listUserOperationClaimModel =_mapper.Map<ListUserOperationClaimModel>(userOperationClaim);
            return listUserOperationClaimModel;
        }
    }
}
