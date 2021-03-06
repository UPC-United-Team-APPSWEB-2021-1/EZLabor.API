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
    public class PublicationRepository: BaseRepository, IPublicationRepository
    {
        public PublicationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Publication publication)
        {
            await _context.Publications.AddAsync(publication);
        }

        public async Task<Publication> FindById(int id)
        {
            return await _context.Publications.FindAsync(id);
        }

        public async Task<IEnumerable<Publication>> ListAsync()
        {
            return await _context.Publications.ToListAsync();
        }
        public void Remove(Publication publication)
        {
            _context.Publications.Remove(publication);
        }

        public void Update(Publication publication)
        {
            _context.Publications.Update(publication);
        }

        public async Task<IEnumerable<Publication>> ListByFreelancerIdAsync(int freelancerId) =>
            await _context.Publications
                .Where(p => p.FreelancerId == freelancerId)
                .Include(p => p.Freelancer)
                .ToListAsync();

        public async Task<IEnumerable<Publication>> ListByEmployerIdAsync(int employerId) =>
            await _context.Publications
                .Where(p => p.EmployerId == employerId)
                .Include(p => p.Employer)
                .ToListAsync();
    }
}
