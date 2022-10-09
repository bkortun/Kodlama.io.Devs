using Core.Persistence.Repositories;
using Core.Security.Entities;
using Core.Security.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Member:Entity
    {
        public Member()
        {

        }

        public Member(int id,string about, GithubAddress address, User user)
        {
            Id = id;
            Address = address;
        }

        public virtual GithubAddress Address { get; set; }

       

    }
}
