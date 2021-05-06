using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Resources
{
    public class SaveFreelancerResource
    {
        [Required]
        [MaxLength(8)]
        [MinLength(8)]
        public int Id { get; set; }

        [Required]
        public string Specially { get; set; }
    }
}
