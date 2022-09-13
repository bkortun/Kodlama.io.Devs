using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GithubAddress:Entity
    {
        public GithubAddress()
        {

        }
        public int MemberId { get; set; }
        public string Address { get; set; }
        public virtual Member? Member { get; set; }

        public GithubAddress(int memberId, string address, int id)
        {
            MemberId = memberId;
            Address = address;
            Id = id;
        }
    }
}
