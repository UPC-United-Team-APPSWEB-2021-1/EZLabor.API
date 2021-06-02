using EZLabor.API.Percistence.Repositories;
using EZLabor.API.Subscription.Domain.Model;
using EZLabor.API.Subscription.Domain.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Subscription.Persistence.Repositories
{
    public class SubscriptionPlanRepository : BaseRepository, ISubscriptionPlanRepository
    {
        public SubscriptionPlanRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(SubscriptionPlan subscriptionPlan)
        {
            await _context.SubscriptionPlans.AddAsync(subscriptionPlan);
        }

        public async Task<SubscriptionPlan> FindById(int id)
        {
            return await _context.SubscriptionPlans.FindAsync(id);
        }

        public async Task<IEnumerable<SubscriptionPlan>> ListAsync()
        {
            return await _context.SubscriptionPlans.ToListAsync();
        }

        public void Remove(SubscriptionPlan subscriptionPlan)
        {
            _context.SubscriptionPlans.Remove(subscriptionPlan);
        }

        public void Update(SubscriptionPlan subscriptionPlan)
        {
            _context.SubscriptionPlans.Update(subscriptionPlan);
        }
    }
}
