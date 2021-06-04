using EZLabor.API.SocialMedia.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Domain.Persistence.Respositories
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> ListAsync();
        Task AddAsync(Comment comment);
        Task<Comment> FindById(int id);
        Task<IEnumerable<Comment>> ListByPublicationIdAsync(int publicationId);
        Task<IEnumerable<Comment>> ListByFreelancerIdAsync(int freelancerId);
        Task<IEnumerable<Comment>> ListByEmployerIdAsync(int employerId);
        void Update(Comment comment);
        void Remove(Comment comment);
    }
}
