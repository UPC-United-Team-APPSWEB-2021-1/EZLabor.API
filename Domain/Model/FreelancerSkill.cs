using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Domain.Models
{
    public class FreelancerSkill
    {
        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
