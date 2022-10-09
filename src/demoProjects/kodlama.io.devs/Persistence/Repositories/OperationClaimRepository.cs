using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class OperationClaimRepository : EfRepositoryBase<OperationClaim, KodlamaioDevsDbContext>, IOperationClaimRepository
    {
        public OperationClaimRepository(KodlamaioDevsDbContext context) : base(context)
        {
        }
    }
}
