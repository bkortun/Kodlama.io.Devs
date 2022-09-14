using Core.Security.Dtos;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Members.Commands.LoginMember
{
    public class LoginMemberCommandRequest: UserForLoginDto,IRequest<AccessToken>
    {
    }
}
