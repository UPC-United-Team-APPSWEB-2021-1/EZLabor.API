using EZLabor.API.Domain.Persistence.Contexts;
using EZLabor.API.SocialMedia.Domain.Model;
using EZLabor.API.SocialMedia.Domain.Persistence.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Persistence.Repositories
{
    public class CommentRepository: BaseRepository, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
        }

        public async Task<Comment> FindById(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<IEnumerable<Comment>> ListAsync()
        {
            return await _context.Comments.ToListAsync();
        }
        public void Remove(Comment comment)
        {
            _context.Comments.Remove(comment);
        }

        public void Update(Comment comment)
        {
            _context.Comments.Update(comment);
        }
        public async Task<IEnumerable<Comment>> ListByPublicationIdAsync(int publicationId) =>
            await _context.Comments
                .Where(p => p.PublicationId == publicationId)
                .Include(p => p.Publication)
                .ToListAsync();

        public async Task<IEnumerable<Comment>> ListByFreelancerIdAsync(int freelancerId) =>
            await _context.Comments
                .Where(p => p.FreelancerId == freelancerId)
                .Include(p => p.Freelancer)
                .ToListAsync();

        public async Task<IEnumerable<Comment>> ListByEmployerIdAsync(int employerId) =>
            await _context.Comments
                .Where(p => p.EmployerId == employerId)
                .Include(p => p.Employer)
                .ToListAsync();
    }
}
