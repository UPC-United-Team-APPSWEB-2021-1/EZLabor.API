using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Resources
{
    public class SavePostulationResource
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public int OfferId { get; set; }

        [Required]
        public int FreelancerId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public float Payment { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string State { get; set; }
    }
}
