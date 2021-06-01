using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Resources
{
    public class MeetingResource
    {
        public int Id { get; set; }
        public int PostulationId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Duration { get; set; }

    }
}
