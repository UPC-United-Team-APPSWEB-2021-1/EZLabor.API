using EZLabor.API.Subscription.Domain.Model;
using EZLabor.API.Subscription.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Subscription.Domain.Services
{
    public interface ISubscriptionPlanService
    {
        Task<IEnumerable<SubscriptionPlan>> ListAsync();
        Task<SubscriptionPlanResponse> SaveAsync(SubscriptionPlan subscriptionPlan);
        Task<SubscriptionPlanResponse> UpdateAsync(int id, SubscriptionPlan subscriptionPlan);
        Task<SubscriptionPlanResponse> DeleteAsync(int id);
        Task<SubscriptionPlanResponse> GetByIdAsync(int id);

    }
}
