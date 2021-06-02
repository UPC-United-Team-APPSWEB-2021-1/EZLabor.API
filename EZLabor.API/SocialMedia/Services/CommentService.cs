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
    public class CommentService: ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CommentResponse> DeleteAsync(int id)
        {
            var existingComment = await _commentRepository.FindById(id);

            if (existingComment == null)
                return new CommentResponse("Comment not found");

            try
            {
                _commentRepository.Remove(existingComment);
                await _unitOfWork.CompleteAsync();

                return new CommentResponse(existingComment);
            }
            catch (Exception ex)
            {
                return new CommentResponse($"An error ocurred while deleting the comment: {ex.Message}");
            }

        }

        public async Task<CommentResponse> GetByIdAsync(int id)
        {
            var existingComment = await _commentRepository.FindById(id);

            if (existingComment == null)
                return new CommentResponse("Comment not found");
            return new CommentResponse(existingComment);
        }

        public async Task<IEnumerable<Comment>> ListAsync()
        {
            return await _commentRepository.ListAsync();
        }

        public async Task<CommentResponse> SaveAsync(Comment comment)
        {
            try
            {
                await _commentRepository.AddAsync(comment);
                await _unitOfWork.CompleteAsync();

                return new CommentResponse(comment);
            }
            catch (Exception ex)
            {
                return new CommentResponse($"An error ocurred while saving the comment: {ex.Message}");
            }
        }

        public async Task<CommentResponse> UpdateAsync(int id, Comment comment)
        {
            var existingComment = await _commentRepository.FindById(id);

            if (existingComment == null)
                return new CommentResponse("Comment not found");

            existingComment.Content = comment.Content;

            try
            {
                _commentRepository.Update(existingComment);
                await _unitOfWork.CompleteAsync();

                return new CommentResponse(existingComment);
            }
            catch (Exception ex)
            {
                return new CommentResponse($"An error ocurred while updating the comment: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Comment>> ListByUserIdAsync(int userId)
        {
            return await _commentRepository.ListByUserIdAsync(userId);
        }

        public async Task<IEnumerable<Comment>> ListByPublicationIdAsync(int publicationId)
        {
            return await _commentRepository.ListByPublicationIdAsync(publicationId);
        }
    }
}
