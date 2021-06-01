using EZLabor.API.Domain.Persistence.Repositories;
using EZLabor.API.Hiring.Domain.Model;
using EZLabor.API.Hiring.Domain.Persistence.Repositories;
using EZLabor.API.Hiring.Domain.Services;
using EZLabor.API.Hiring.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Services
{
    public class RequirementService: IRequirementService
    {
        private readonly IRequirementRepository _requirementRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RequirementService(IRequirementRepository requirementRepository, IUnitOfWork unitOfWork)
        {
            _requirementRepository = requirementRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<Requirement>> ListAsync()
        {
            return await _requirementRepository.ListAsync();
        }
        public async Task<IEnumerable<Requirement>> ListByOfferId(int offerId)
        {
            return await _requirementRepository.ListByOfferIdAsync(offerId);
        }
        public async Task<RequirementResponse> GetByIdAsync(int id)
        {
            var existingRequirement = await _requirementRepository.FindById(id);
            if (existingRequirement == null)
                return new RequirementResponse("Requirement not found");
            return new RequirementResponse(existingRequirement);
        }
        public async Task<RequirementResponse> SaveAsync(Requirement requirement)
        {
            try
            {
                await _requirementRepository.AddAsync(requirement);
                await _unitOfWork.CompleteAsync();

                return new RequirementResponse(requirement);
            }
            catch (Exception ex)
            {
                return new RequirementResponse($"An error ocurred while saving the requirement: {ex.Message}");
            }
        }
        public async Task<RequirementResponse> UpdateAsync(int id, Requirement requirement)
        {
            var existingRequirement = await _requirementRepository.FindById(id);
            if (existingRequirement == null)
                return new RequirementResponse("Requirement not found");
            try
            {
                _requirementRepository.Update(existingRequirement);
                await _unitOfWork.CompleteAsync();

                return new RequirementResponse(existingRequirement);
            }
            catch (Exception ex)
            {
                return new RequirementResponse($"An error ocurred while updating the requirement: {ex.Message}");
            }

        }
        public async Task<RequirementResponse> DeleteAsync(int id)
        {
            var existingRequirement = await _requirementRepository.FindById(id);
            if (existingRequirement == null)
                return new RequirementResponse("Requirement not found");
            try
            {
                _requirementRepository.Remove(existingRequirement);
                await _unitOfWork.CompleteAsync();

                return new RequirementResponse(existingRequirement);
            }
            catch (Exception ex)
            {
                return new RequirementResponse($"An error ocurred while deleting the requirement: {ex.Message}");
            }

        }
    }
}
