using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Dtos
{
    public class ListGithubAddressDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
