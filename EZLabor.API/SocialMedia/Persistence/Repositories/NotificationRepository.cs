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
    public class NotificationRepository : BaseRepository, INotificationRepository
    {
        public NotificationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Notification notification)
        {
            await _context.Notifications.AddAsync(notification);
        }

        public async Task<Notification> FindById(int id)
        {
            return await _context.Notifications.FindAsync(id);
        }

        public async Task<IEnumerable<Notification>> ListAsync()
        {
            return await _context.Notifications.ToListAsync();
        }
        public void Remove(Notification notification)
        {
            _context.Notifications.Remove(notification);
        }

        public void Update(Notification notification)
        {
            _context.Notifications.Update(notification);
        }

        public async Task<IEnumerable<Notification>> ListByFreelancerIdAsync(int freelancerId) =>
            await _context.Notifications
                .Where(p => p.FreelancerId == freelancerId)
                .Include(p => p.Freelancer)
                .ToListAsync();

        public async Task<IEnumerable<Notification>> ListByEmployerIdAsync(int employerId) =>
            await _context.Notifications
                .Where(p => p.EmployerId == employerId)
                .Include(p => p.Employer)
                .ToListAsync();
    }
}
