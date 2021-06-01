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
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IUnitOfWork _unitOfWork;


        public OfferService(IOfferRepository offerRepository, IUnitOfWork unitOfWork)
        {
            _offerRepository = offerRepository;
            _unitOfWork = unitOfWork;

        }


        public async Task<IEnumerable<Offer>> ListAsync()
        {
            return await _offerRepository.ListAsync();
        }

        public async Task<IEnumerable<Offer>> ListByEmployerId(int employerId)
        {
            return await _offerRepository.ListByEmployerIdAsync(employerId);
        }

        public async Task<OfferResponse> GetByIdAsync(int id)
        {
            var existingOffer = await _offerRepository.FindById(id);

            if (existingOffer == null)
                return new OfferResponse("Offer not found");
            return new OfferResponse(existingOffer);
        }

        public async Task<OfferResponse> SaveAsync(Offer offer)
        {
            try
            {
                await _offerRepository.AddAsync(offer);
                await _unitOfWork.CompleteAsync();

                return new OfferResponse(offer);
            }
            catch (Exception ex)
            {
                return new OfferResponse($"An error ocurred while saving the offer: {ex.Message}");
            }
        }
        public async Task<OfferResponse> UpdateAsync(int id, Offer offer)
        {
            var existingOffer = await _offerRepository.FindById(id);

            if (existingOffer == null)
                return new OfferResponse("Offer not found");


            try
            {
                _offerRepository.Update(existingOffer);
                await _unitOfWork.CompleteAsync();

                return new OfferResponse(existingOffer);
            }
            catch (Exception ex)
            {
                return new OfferResponse($"An error ocurred while updating the offer: {ex.Message}");
            }

        }
        public async Task<OfferResponse> DeleteAsync(int id)
        {
            var existingOffer = await _offerRepository.FindById(id);

            if (existingOffer == null)
                return new OfferResponse("Offer not found");

            try
            {
                _offerRepository.Remove(existingOffer);
                await _unitOfWork.CompleteAsync();

                return new OfferResponse(existingOffer);
            }
            catch (Exception ex)
            {
                return new OfferResponse($"An error ocurred while deleting the offer: {ex.Message}");
            }
        }



    }
}
