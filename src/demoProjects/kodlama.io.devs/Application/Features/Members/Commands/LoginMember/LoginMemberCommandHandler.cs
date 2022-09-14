using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Members.Commands.LoginMember
{
    public class LoginMemberCommandHandler : IRequestHandler<LoginMemberCommandRequest, AccessToken>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly ITokenHelper _tokenHelper;

        public LoginMemberCommandHandler(IMemberRepository memberRepository, IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper)
        {
            _memberRepository = memberRepository;
            _userOperationClaimRepository = userOperationClaimRepository;
            _tokenHelper = tokenHelper;
        }

        public async Task<AccessToken> Handle(LoginMemberCommandRequest request, CancellationToken cancellationToken)
        {
            Member member = await _memberRepository.GetAsync(m => m.Email == request.Email);
            //todo email doğrulama ve business rulesa ekleme
            if (!HashingHelper.VerifyPasswordHash(request.Password, member.PasswordHash, member.PasswordSalt))
                throw new BusinessException("Password wrong!");
            IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(m => m.UserId == member.Id,
                include:u=>u.Include(o=>o.OperationClaim));
            
            AccessToken accessToken =_tokenHelper.CreateToken(member, userOperationClaims.Items.Select(e=>e.OperationClaim).ToList());
            return accessToken;
        }
    }
}
