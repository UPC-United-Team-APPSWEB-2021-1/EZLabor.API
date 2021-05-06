using EZLabor.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Domain.Services.Communications
{
    public class FreelancerKnowledgeResponse: BaseResponse<FreelancerKnowledge>
    {
        public FreelancerKnowledgeResponse(FreelancerKnowledge resource) : base(resource)
        {
        }

        public FreelancerKnowledgeResponse(string message) : base(message)
        {
        }
    }
}
