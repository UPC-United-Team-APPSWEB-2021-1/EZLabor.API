using EZLabor.API.SocialMedia.Domain.Model;
using EZLabor.API.SocialMedia.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Domain.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> ListAsync();
        Task<IEnumerable<Comment>> ListByPublicationIdAsync(int publicationId);
        Task<IEnumerable<Comment>> ListByUserIdAsync(int userId);
        Task<CommentResponse> GetByIdAsync(int id);
        Task<CommentResponse> SaveAsync(Comment comment);
        Task<CommentResponse> UpdateAsync(int id, Comment comment);
        Task<CommentResponse> DeleteAsync(int id);
    }
}
