using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Domain.Models
{
    public class FreelancerKnowledge
    {
        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
        public int KnowledgeId { get; set; }
        public Knowledge Knowledge { get; set; }
    }
}
