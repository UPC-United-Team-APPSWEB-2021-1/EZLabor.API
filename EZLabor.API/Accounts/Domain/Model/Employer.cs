using EZLabor.API.Hiring.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Accounts.Domain.Model
{
    public class Employer: User
    {
        public string Name { get; set; }
        public string Website { get; set; }
        public string CorporativeEmail { get; set; }
        public List<Proposal> Proposals { get; set; }

        public List<Offer> Offers { get; set; }
    }
}
