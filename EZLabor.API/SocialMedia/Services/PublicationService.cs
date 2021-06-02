﻿using EZLabor.API.Domain.Persistence.Repositories;
using EZLabor.API.SocialMedia.Domain.Model;
using EZLabor.API.SocialMedia.Domain.Persistence.Respositories;
using EZLabor.API.SocialMedia.Domain.Services;
using EZLabor.API.SocialMedia.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Services
{
    public class PublicationService: IPublicationService
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PublicationService(IPublicationRepository publicationRepository, IUnitOfWork unitOfWork)
        {
            _publicationRepository = publicationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PublicationResponse> DeleteAsync(int id)
        {
            var existingPublication = await _publicationRepository.FindById(id);

            if (existingPublication == null)
                return new PublicationResponse("Publication not found");

            try
            {
                _publicationRepository.Remove(existingPublication);
                await _unitOfWork.CompleteAsync();

                return new PublicationResponse(existingPublication);
            }
            catch (Exception ex)
            {
                return new PublicationResponse($"An error ocurred while deleting the publication: {ex.Message}");
            }

        }

        public async Task<PublicationResponse> GetByIdAsync(int id)
        {
            var existingPublication = await _publicationRepository.FindById(id);

            if (existingPublication == null)
                return new PublicationResponse("Publication not found");
            return new PublicationResponse(existingPublication);
        }

        public async Task<IEnumerable<Publication>> ListAsync()
        {
            return await _publicationRepository.ListAsync();
        }

        public async Task<PublicationResponse> SaveAsync(Publication publication)
        {
            try
            {
                await _publicationRepository.AddAsync(publication);
                await _unitOfWork.CompleteAsync();

                return new PublicationResponse(publication);
            }
            catch (Exception ex)
            {
                return new PublicationResponse($"An error ocurred while saving the publication: {ex.Message}");
            }
        }

        public async Task<PublicationResponse> UpdateAsync(int id, Publication publication)
        {
            var existingPublication = await _publicationRepository.FindById(id);

            if (existingPublication == null)
                return new PublicationResponse("Publication not found");

            existingPublication.Name = publication.Name;

            try
            {
                _publicationRepository.Update(existingPublication);
                await _unitOfWork.CompleteAsync();

                return new PublicationResponse(existingPublication);
            }
            catch (Exception ex)
            {
                return new PublicationResponse($"An error ocurred while updating the publication: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Publication>> ListByUserIdAsync(int userId)
        {
            return await _publicationRepository.ListByUserIdAsync(userId);
        }
    }
}
