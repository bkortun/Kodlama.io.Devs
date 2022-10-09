using Application.Features.UserOperationClaims.Dtos;
using Application.Services.Repositories;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.CreateOperationClaim
{
    public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommandRequest, CreateUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;

        public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IOperationClaimRepository operationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<CreateUserOperationClaimDto> Handle(CreateUserOperationClaimCommandRequest request, CancellationToken cancellationToken)
        {
            OperationClaim operationClaim = new() { Name = request.ClaimName };
            OperationClaim addedOperationClaim =await _operationClaimRepository.AddAsync(operationClaim);
            UserOperationClaim userOperationClaim = new() { OperationClaimId=addedOperationClaim.Id,UserId=request.UserId};
            UserOperationClaim addedUserOperationClaim= await _userOperationClaimRepository.AddAsync(userOperationClaim);
            return new()
            {
                Id = userOperationClaim.Id,
                UserId = addedUserOperationClaim.UserId,
                Name = addedUserOperationClaim.OperationClaim.Name
            };
        }
    }
}
