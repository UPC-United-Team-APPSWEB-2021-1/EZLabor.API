
using EZLabor.API.Hiring.Domain.Model;
using EZLabor.API.Hiring.Domain.Persistence.Context;
using EZLabor.API.Hiring.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Persistence.Repositories
{
    public class PostulationRepository: BaseRepository, IPostulationRepository
    {

        public PostulationRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Postulation>> ListAsync()
        {
            return await _context.Postulations.ToListAsync();
        }
        public async Task<IEnumerable<Postulation>> ListByOfferIdAsync(int offerId)
        {
            return await _context.Postulations
                .Where(pt => pt.OfferId == offerId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Postulation>> ListByFreelancerIdAsync(int freelancerId)
        {
            return await _context.Postulations
                .Where(pt => pt.FreelancerId == freelancerId)
                .ToListAsync();
        }

        public async Task AddAsync(Postulation postulation)
        {
            await _context.Postulations.AddAsync(postulation);
        }

        public async Task<Postulation> FindById(int id)
        {
            return await _context.Postulations.FindAsync(id);
        }
        public void Update(Postulation postulation)
        {
            _context.Postulations.Update(postulation);
        }
        public void Remove(Postulation postulation)
        {
            _context.Postulations.Remove(postulation);
        }

    }
}
