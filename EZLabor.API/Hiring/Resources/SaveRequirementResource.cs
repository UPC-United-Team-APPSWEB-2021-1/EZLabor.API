using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Resources
{
    public class SaveRequirementResource
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int SkillLevel { get; set; }

        [Required]
        public int OfferId { get; set; }
    }
}
