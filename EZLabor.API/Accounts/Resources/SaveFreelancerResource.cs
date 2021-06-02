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
        [MaxLength(20)]
        [MinLength(3)]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        public string Specially { get; set; }
    }
}
