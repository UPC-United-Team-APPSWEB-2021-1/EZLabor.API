using EZLabor.API.Domain.Services.Communications;
using EZLabor.API.Hiring.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Domain.Services.Communications
{
    public class PostulationResponse: BaseResponse<Postulation>
    {
        public PostulationResponse(Postulation resource) : base(resource)
        {
        }

        public PostulationResponse(string message) : base(message)
        {
        }
    }
}
