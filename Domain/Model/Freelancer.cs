using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Domain.Models
{
    public class Freelancer : User
    {
        public int Rating { get; set; }
        public string Specially { get; set; }
        public List<FreelancerSkill> FreelancerSkills { get; set; }
        public List<Proposal> Proposals { get; set; }

    }
}
