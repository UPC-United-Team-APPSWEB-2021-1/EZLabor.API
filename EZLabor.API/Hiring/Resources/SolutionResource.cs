using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Resources
{
    public class SolutionResource
    {
        public int Id { get; set; }

        public int PostulationId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string State { get; set; }
    }
}
