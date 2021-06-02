using EZLabor.API.Domain.Persistence.Repositories;
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
    public class QualificationService: IQualificationService
    {        
            private readonly IQualificationRepository _qualificationRepository;
            private readonly IUnitOfWork _unitOfWork;

            public QualificationService(IQualificationRepository qualificationRepository, IUnitOfWork unitOfWork)
            {
                _qualificationRepository = qualificationRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<QualificationResponse> DeleteAsync(int id)
            {
                var existingQualification = await _qualificationRepository.FindById(id);

                if (existingQualification == null)
                    return new QualificationResponse("Qualification not found");

                try
                {
                    _qualificationRepository.Remove(existingQualification);
                    await _unitOfWork.CompleteAsync();

                    return new QualificationResponse(existingQualification);
                }
                catch (Exception ex)
                {
                    return new QualificationResponse($"An error ocurred while deleting the qualification: {ex.Message}");
                }

            }

            public async Task<QualificationResponse> GetByIdAsync(int id)
            {
                var existingQualification = await _qualificationRepository.FindById(id);

                if (existingQualification == null)
                    return new QualificationResponse("Qualification not found");
                return new QualificationResponse(existingQualification);
            }

            public async Task<IEnumerable<Qualification>> ListAsync()
            {
                return await _qualificationRepository.ListAsync();
            }

            public async Task<QualificationResponse> SaveAsync(Qualification qualification)
            {
                try
                {
                    await _qualificationRepository.AddAsync(qualification);
                    await _unitOfWork.CompleteAsync();

                    return new QualificationResponse(qualification);
                }
                catch (Exception ex)
                {
                    return new QualificationResponse($"An error ocurred while saving the qualification: {ex.Message}");
                }
            }

            public async Task<QualificationResponse> UpdateAsync(int id, Qualification qualification)
            {
                var existingQualification = await _qualificationRepository.FindById(id);

                if (existingQualification == null)
                    return new QualificationResponse("Qualification not found");

                existingQualification.Comment = qualification.Comment;

                try
                {
                    _qualificationRepository.Update(existingQualification);
                    await _unitOfWork.CompleteAsync();

                    return new QualificationResponse(existingQualification);
                }
                catch (Exception ex)
                {
                    return new QualificationResponse($"An error ocurred while updating the qualification: {ex.Message}");
                }
            }

            public async Task<IEnumerable<Qualification>> ListBySolutionIdAsync(int solutionId)
            {
                return await _qualificationRepository.ListBySolutionIdAsync(solutionId);
            }
        }
}
