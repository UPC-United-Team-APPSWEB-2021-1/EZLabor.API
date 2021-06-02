using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Accounts.Resources
{
    public class SaveSkillResource
    {
        [Required]
        public string TechnologyName { get; set; }
    }
}
