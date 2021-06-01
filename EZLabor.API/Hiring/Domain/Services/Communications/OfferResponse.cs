using EZLabor.API.Domain.Services.Communications;
using EZLabor.API.Hiring.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Domain.Services.Communications
{
    public class OfferResponse: BaseResponse<Offer>
    {
        public OfferResponse(Offer resource) : base(resource)
        {

        }

        public OfferResponse(string message) : base(message)
        {

        }
    }
}
