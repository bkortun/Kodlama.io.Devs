using Core.Security.Dtos;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Members.Commands.RegisterMember
{
    public class RegisterMemberCommandRequest:UserForRegisterDto,IRequest<AccessToken>
    {
        
    }
}
