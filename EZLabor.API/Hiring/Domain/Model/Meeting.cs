using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Domain.Model
{
    public class Meeting
    {
        public int Id { get; set; }
        
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Duration { get; set; }

        public Postulation Postulation { get; set; }
        public int PostulationId { get; set; }
    }
}
