using Application.Services.Repositories;
using AutoMapper;
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

namespace Application.Features.Members.Commands.RegisterMember
{
    public class RegisterMemberCommandHandler : IRequestHandler<RegisterMemberCommandRequest, AccessToken>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;

        public RegisterMemberCommandHandler(IMemberRepository memberRepository, IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _userOperationClaimRepository = userOperationClaimRepository;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
        }
        public async Task<AccessToken> Handle(RegisterMemberCommandRequest request, CancellationToken cancellationToken)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

            Member member = _mapper.Map<Member>(request);
            member.PasswordHash = passwordHash;
            member.PasswordSalt = passwordSalt;
            member.Status = true;

            Member addedMember = await _memberRepository.AddAsync(member);

            AccessToken accessToken = _tokenHelper.CreateToken(addedMember, new List<OperationClaim>());
            return accessToken;
        }
    }
}
