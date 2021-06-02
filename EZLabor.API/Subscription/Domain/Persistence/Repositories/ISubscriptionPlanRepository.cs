using EZLabor.API.Subscription.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Subscription.Domain.Persistence.Repositories
{
    public interface ISubscriptionPlanRepository
    {
        Task<IEnumerable<SubscriptionPlan>> ListAsync();
        Task AddAsync(SubscriptionPlan subscriptionPlan);
        Task<SubscriptionPlan> FindById(int id);
        void Update(SubscriptionPlan subscriptionPlan);
        void Remove(SubscriptionPlan subscriptionPlan);
    }
}
