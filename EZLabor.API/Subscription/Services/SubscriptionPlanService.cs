using EZLabor.API.Commons.Domain.Persistence.Repositories;
using EZLabor.API.Subscription.Domain.Model;
using EZLabor.API.Subscription.Domain.Persistence.Repositories;
using EZLabor.API.Subscription.Domain.Services;
using EZLabor.API.Subscription.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Subscription.Services
{
    public class SubscriptionPlanService : ISubscriptionPlanService
    {

        private readonly ISubscriptionPlanRepository _subscriptionPlanRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SubscriptionPlanService(ISubscriptionPlanRepository subscriptionPlanRepository, IUnitOfWork unitOfWork)
        {
            _subscriptionPlanRepository = subscriptionPlanRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<SubscriptionPlanResponse> DeleteAsync(int id)
        {
            var existingSubscriptionPlan = await _subscriptionPlanRepository.FindById(id);

            if (existingSubscriptionPlan == null)
                return new SubscriptionPlanResponse("Subscription Plan not found");

            try
            {
                _subscriptionPlanRepository.Remove(existingSubscriptionPlan);
                await _unitOfWork.CompleteAsync();

                return new SubscriptionPlanResponse(existingSubscriptionPlan);
            }
            catch (Exception ex)
            {
                return new SubscriptionPlanResponse($"An error ocurred while deleting the subscription plan: {ex.Message}");
            }
        }

        public async Task<SubscriptionPlanResponse> GetByIdAsync(int id)
        {
            var existingSubscriptionPlan = await _subscriptionPlanRepository.FindById(id);

            if (existingSubscriptionPlan == null)
                return new SubscriptionPlanResponse("Subscription Plan not found");
            return new SubscriptionPlanResponse(existingSubscriptionPlan);
        }


        public async Task<IEnumerable<SubscriptionPlan>> ListAsync()
        {
            return await _subscriptionPlanRepository.ListAsync();
        }

        public async Task<SubscriptionPlanResponse> SaveAsync(SubscriptionPlan subscriptionPlan)
        {
            try
            {
                await _subscriptionPlanRepository.AddAsync(subscriptionPlan);
                await _unitOfWork.CompleteAsync();

                return new SubscriptionPlanResponse(subscriptionPlan);
            }
            catch (Exception ex)
            {
                return new SubscriptionPlanResponse($"An error ocurred while saving the subscription plan: {ex.Message}");
            }
        }

        public async Task<SubscriptionPlanResponse> UpdateAsync(int id, SubscriptionPlan subscriptionPlan)
        {
            var existingSubscriptionPlan = await _subscriptionPlanRepository.FindById(id);

            if (existingSubscriptionPlan == null)
                return new SubscriptionPlanResponse("Subscription plan not found");

            existingSubscriptionPlan.Name = subscriptionPlan.Name;

            try
            {
                await _subscriptionPlanRepository.AddAsync(subscriptionPlan);
                await _unitOfWork.CompleteAsync();

                return new SubscriptionPlanResponse(subscriptionPlan);
            }
            catch (Exception ex)
            {
                return new SubscriptionPlanResponse($"An error ocurred while saving the subscription plan: {ex.Message}");
            }
        }

    }
}
