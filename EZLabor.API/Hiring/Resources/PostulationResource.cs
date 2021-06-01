using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Resources
{
    public class PostulationResource
    {
        public int Id { get; set; }

        public int OfferId { get; set; }
        public int FreelancerId { get; set; }
        public string Description { get; set; }
        public float Payment { get; set; }
        public DateTime CreatedAt { get; set; }
        public string State { get; set; }
    }
}
