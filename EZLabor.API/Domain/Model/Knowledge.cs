using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Domain.Models
{
    public class Knowledge
    {
        public int Id { get; set; }
        public string TechnologyName { get; set; }
        public string CertificateUrl { get; set; }
        public List<FreelancerKnowledge> FreelancerKnowledges { get; set; }
    }
}
