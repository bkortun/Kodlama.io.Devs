using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Models
{
    public class ListGithubAddressModel:BasePageableModel
    {
        public IList<GithubAddress> Items { get; set; }
    }
}
