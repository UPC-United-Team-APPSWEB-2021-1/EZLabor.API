using EZLabor.API.Domain.Services.Communications;
using EZLabor.API.Subscription.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Subscription.Domain.Services.Communications
{
    public class SubscriptionPlanResponse : BaseResponse<SubscriptionPlan>
    {
        public SubscriptionPlanResponse(SubscriptionPlan resource) : base(resource)
        {
        }
        public SubscriptionPlanResponse(string message) : base(message)
        {
        }
    }
}
