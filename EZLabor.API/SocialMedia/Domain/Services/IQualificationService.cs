using EZLabor.API.SocialMedia.Domain.Model;
using EZLabor.API.SocialMedia.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Domain.Services
{
    public interface IQualificationService
    {
        Task<IEnumerable<Qualification>> ListAsync();
        Task<IEnumerable<Qualification>> ListBySolutionIdAsync(int solutionId);
        Task<QualificationResponse> GetByIdAsync(int id);
        Task<QualificationResponse> SaveAsync(Qualification qualification);
        Task<QualificationResponse> UpdateAsync(int id, Qualification qualification);
        Task<QualificationResponse> DeleteAsync(int id);
    }
}
