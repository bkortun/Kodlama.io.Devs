using Application.Features.UserOperationClaims.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.CreateOperationClaim
{
    public class CreateUserOperationClaimCommandRequest:IRequest<CreateUserOperationClaimDto>
    {
        public int UserId { get; set; }
        public string ClaimName { get; set; }
    }
}
