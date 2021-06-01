using EZLabor.API.Domain.Services.Communications;
using EZLabor.API.Hiring.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Domain.Services.Communications
{
    public class RequirementResponse: BaseResponse<Requirement>
    {
        public RequirementResponse(Requirement resource) : base(resource)
        {
        }

        public RequirementResponse(string message) : base(message)
        {
        }

    }
}
