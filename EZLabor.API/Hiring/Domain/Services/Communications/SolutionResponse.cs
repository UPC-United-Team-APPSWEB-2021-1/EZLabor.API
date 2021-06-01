using EZLabor.API.Domain.Services.Communications;
using EZLabor.API.Hiring.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Domain.Services.Communications
{
    public class SolutionResponse: BaseResponse<Solution>
    {
        public SolutionResponse(Solution resource) : base(resource)
        {
        }

        public SolutionResponse(string message) : base(message)
        {
        }
    }
}
