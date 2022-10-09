using Core.Security.Entities;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthService
{
    public interface IAuthService
    {
        Task<AccessToken> CreateAccessTokenAsync(User user);
        Task<RefreshToken> CreateRefreshTokenAsync(User user,string ipAddress);
        Task<RefreshToken> AddRefreshTokenAsync(RefreshToken refreshToken);
    }
}
