using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Domain.Model
{
    public class Solution
    {
        public int Id { get; set; }
        
        
        public DateTime CreatedAt { get; set; }
        public string State { get; set; }

        public Postulation Postulation { get; set; }
        public int PostulationId { get; set; }

    }
}
