
using EZLabor.API.Domain.Services.Communications;
using EZLabor.API.SocialMedia.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Domain.Services.Communications
{
    public class QualificationResponse: BaseResponse<Qualification>
    {
        public QualificationResponse(Qualification resource) : base(resource)
        {
        }

        public QualificationResponse(string message) : base(message)
        {
        }
    }
}
