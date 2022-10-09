using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Register
{
    public class RegisterAuthCommandHandler : IRequestHandler<RegisterAuthCommandRequest, RegisterDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _businessRules;

        public RegisterAuthCommandHandler(IUserRepository userRepository, IAuthService authService, AuthBusinessRules businessRules, IMemberRepository memberRepository)
        {
            _userRepository = userRepository;
            _authService = authService;
            _businessRules = businessRules;
            _memberRepository = memberRepository;
        }

        public async Task<RegisterDto> Handle(RegisterAuthCommandRequest request, CancellationToken cancellationToken)
        {
            await _businessRules.EmailCanNotBeDuplicatedWhenRegistered(request.UserForRegisterDto.Email);
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password,out passwordHash,out passwordSalt);
            User newUser = new()
            {
                Email = request.UserForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                FirstName = request.UserForRegisterDto.FirstName,
                LastName = request.UserForRegisterDto.LastName,
                Status = true
            };
            User registeredUser =await _userRepository.AddAsync(newUser);

            //todo Burası tasarıa uygun mu kontrol et
            Member member = new() { Id=registeredUser.Id };
            await _memberRepository.AddAsync(member);

            AccessToken createdAccessToken= await _authService.CreateAccessTokenAsync(registeredUser);
            RefreshToken createdRefreshToken=await _authService.CreateRefreshTokenAsync(registeredUser, request.IpAddress);
            RefreshToken addedRefreshToken = await _authService.AddRefreshTokenAsync(createdRefreshToken);

            return new()
            {
                AccessToken = createdAccessToken,
                RefreshToken = addedRefreshToken,
            };
        }
    }
}
