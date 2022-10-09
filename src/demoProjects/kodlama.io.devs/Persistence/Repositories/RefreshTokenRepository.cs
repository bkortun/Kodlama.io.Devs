using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, KodlamaioDevsDbContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(KodlamaioDevsDbContext context) : base(context)
        {
        }
    }
}
