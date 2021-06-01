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
    public class SolutionService: ISolutionService
    {
        private readonly ISolutionRepository _solutionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SolutionService(ISolutionRepository solutionRepository, IUnitOfWork unitOfWork)
        {
            _solutionRepository = solutionRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task<IEnumerable<Solution>> ListAsync()
        {
            return await _solutionRepository.ListAsync();
        }
        public async Task<SolutionResponse> GetByIdAsync(int id)
        {
            var existingSolution = await _solutionRepository.FindById(id);

            if (existingSolution == null)
                return new SolutionResponse("Solution not found");
            return new SolutionResponse(existingSolution);
        }
        public async Task<SolutionResponse> SaveAsync(Solution solution)
        {
            try
            {
                await _solutionRepository.AddAsync(solution);
                await _unitOfWork.CompleteAsync();

                return new SolutionResponse(solution);
            }
            catch (Exception ex)
            {
                return new SolutionResponse($"An error ocurred while saving the solution: {ex.Message}");
            }
        }
        public async Task<SolutionResponse> UpdateAsync(int id, Solution solution)
        {
            var existingSolution = await _solutionRepository.FindById(id);

            if (existingSolution == null)
                return new SolutionResponse("Solution not found");
            try
            {
                _solutionRepository.Update(existingSolution);
                await _unitOfWork.CompleteAsync();

                return new SolutionResponse(existingSolution);
            }
            catch (Exception ex)
            {
                return new SolutionResponse($"An error ocurred while updating the solution: {ex.Message}");
            }

        }
        public async Task<SolutionResponse> DeleteAsync(int id)
        {
            var existingSolution = await _solutionRepository.FindById(id);

            if (existingSolution == null)
                return new SolutionResponse("Solution not found");
            try
            {
                _solutionRepository.Remove(existingSolution);
                await _unitOfWork.CompleteAsync();

                return new SolutionResponse(existingSolution);
            }
            catch (Exception ex)
            {
                return new SolutionResponse($"An error ocurred while deleting the solution: {ex.Message}");
            }

        }
    }
}
