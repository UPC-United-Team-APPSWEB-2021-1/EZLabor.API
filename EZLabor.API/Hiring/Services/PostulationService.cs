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
    public class PostulationService: IPostulationService
    {
        private readonly IPostulationRepository _postulationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostulationService(IPostulationRepository postulationRepository, IUnitOfWork unitOfWork)
        {
            _postulationRepository = postulationRepository;
            _unitOfWork = unitOfWork;

        }


        public async Task<IEnumerable<Postulation>> ListAsync()
        {
            return await _postulationRepository.ListAsync();
        }
        public async Task<IEnumerable<Postulation>> ListByFreelancerId(int freelancerId)
        {
            return await _postulationRepository.ListByFreelancerIdAsync(freelancerId);
        }

        public async Task<IEnumerable<Postulation>> ListByOfferId(int offerId)
        {
            return await _postulationRepository.ListByOfferIdAsync(offerId);
        }

        public async Task<PostulationResponse> GetByIdAsync(int id)
        {
            var existingPostulation = await _postulationRepository.FindById(id);

            if (existingPostulation == null)
                return new PostulationResponse("Postulation not found");
            return new PostulationResponse(existingPostulation);
        }
        public async Task<PostulationResponse> SaveAsync(Postulation postulation)
        {
            try
            {
                await _postulationRepository.AddAsync(postulation);
                await _unitOfWork.CompleteAsync();

                return new PostulationResponse(postulation);
            }
            catch (Exception ex)
            {
                return new PostulationResponse($"An error ocurred while saving the postulation: {ex.Message}");
            }
        }
        public async Task<PostulationResponse> UpdateAsync(int id, Postulation skill)
        {
            var existingPostulation = await _postulationRepository.FindById(id);

            if (existingPostulation == null)
                return new PostulationResponse("Postulation not found");

            try
            {
                _postulationRepository.Update(existingPostulation);
                await _unitOfWork.CompleteAsync();
                
                return new PostulationResponse(existingPostulation);
            }
            catch (Exception ex)
            {
                return new PostulationResponse($"An error ocurred while updating the postulation: {ex.Message}");
            }

        }
        public async Task<PostulationResponse> DeleteAsync(int id)
        {
            var existingPostulation = await _postulationRepository.FindById(id);

            if (existingPostulation == null)
                return new PostulationResponse("Postulation not found");

            try
            {
                _postulationRepository.Remove(existingPostulation);
                await _unitOfWork.CompleteAsync();

                return new PostulationResponse(existingPostulation);
            }
            catch (Exception ex)
            {
                return new PostulationResponse($"An error ocurred while deleting the postulation: {ex.Message}");
            }
        }





    }
}
