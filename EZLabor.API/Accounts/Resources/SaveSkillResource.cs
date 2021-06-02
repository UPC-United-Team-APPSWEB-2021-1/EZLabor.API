using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Resources
{
    public class SaveSkillResource
    {
        [Required]
        public string TechnologyName { get; set; }
    }
}
