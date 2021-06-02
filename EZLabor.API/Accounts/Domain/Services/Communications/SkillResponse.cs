using EZLabor.API.Accounts.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Accounts.Domain.Services.Communications
{
    public class SkillResponse : BaseResponse<Skill>
    {
        public SkillResponse(Skill resource) : base(resource)
        {
        }

        public SkillResponse(string message) : base(message)
        {
        }
    }
}
