using Application.Features.UserOperationClaims.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Models
{
    public class ListUserOperationClaimModel:BasePageableModel
    {
        public IList<ListUserOperationClaimDto> Items { get; set; }
    }
}
