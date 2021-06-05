
using EZLabor.API.Domain.Persistence.Contexts;
using EZLabor.API.Hiring.Domain.Model;
using EZLabor.API.Hiring.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Persistence.Repositories
{
    public class OfferRepository: BaseRepository, IOfferRepository
    {
        public OfferRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Offer>> ListAsync()
        {
            return await _context.Offers.ToListAsync();
        }
        public async Task<IEnumerable<Offer>> ListByEmployerIdAsync(int employerId)
        {
            return await _context.Offers
                .Where(pt => pt.EmployerId == employerId)
                .ToListAsync();
        }

        public async Task AddAsync(Offer offer)
        {
            await _context.Offers.AddAsync(offer);
        }

        public async Task<Offer> FindById(int id)
        {
            return await _context.Offers.FindAsync(id);
        }
        public void Update(Offer offer)
        {
            _context.Offers.Update(offer);
        }
        public void Remove(Offer offer)
        {
            _context.Offers.Remove(offer);
        }

        
    }
}
