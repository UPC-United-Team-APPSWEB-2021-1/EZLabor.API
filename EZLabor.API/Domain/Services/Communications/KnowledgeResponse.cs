using EZLabor.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Domain.Services.Communications
{
    public class KnowledgeResponse: BaseResponse<Knowledge>
    {
        public KnowledgeResponse(Knowledge resource) : base(resource)
        {
        }

        public KnowledgeResponse(string message) : base(message)
        {
        }
    }
}
