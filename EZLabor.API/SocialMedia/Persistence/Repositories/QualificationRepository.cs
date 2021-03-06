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
    public class QualificationRepository: BaseRepository, IQualificationRepository
    {
        public QualificationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Qualification qualification)
        {
            await _context.Qualifications.AddAsync(qualification);
        }

        public async Task<Qualification> FindById(int id)
        {
            return await _context.Qualifications.FindAsync(id);
        }

        public async Task<IEnumerable<Qualification>> ListAsync()
        {
            return await _context.Qualifications.ToListAsync();
        }
        public void Remove(Qualification qualification)
        {
            _context.Qualifications.Remove(qualification);
        }

        public void Update(Qualification qualification)
        {
            _context.Qualifications.Update(qualification);
        }

        public async Task<IEnumerable<Qualification>> ListBySolutionIdAsync(int solutionId) =>
            await _context.Qualifications
                .Where(p => p.SolutionId == solutionId)
                .Include(p => p.Solution)
                .ToListAsync();
    }
}
