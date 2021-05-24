using EZLabor.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Domain.Services.Communications
{
    public class FreelancerSkillResponse : BaseResponse<FreelancerSkill>
    {
        public FreelancerSkillResponse(FreelancerSkill resource) : base(resource)
        {
        }

        public FreelancerSkillResponse(string message) : base(message)
        {
        }
    }
}
