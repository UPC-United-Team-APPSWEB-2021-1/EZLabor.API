using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Resources
{
    public class SaveSolutionResource
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int PostulationId { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public string State { get; set; }
    }
}
