using Application.Features.UserOperationClaims.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Queries.ListByEmailOperationClaim
{
    public class ListByEmailUserOperationClaimQueryRequest:IRequest<ListByEmailUserOperationClaimModel>
    {
        public string Email { get; set; }
    }
}
