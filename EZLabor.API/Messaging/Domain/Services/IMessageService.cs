using EZLabor.API.Messaging.Domain.Model;
using EZLabor.API.Messaging.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Messaging.Domain.Services
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> ListAsync();
        Task<IEnumerable<Message>> ListByFreelancerIdAsync(int freelancerId);
        Task<IEnumerable<Message>> ListByEmployerIdAsync(int employerId);
        Task<IEnumerable<Message>> ListByFreelancerIdAndEmployerIdAsync(int freelancerId, int employerId);
        Task<MessageResponse> SaveAsync(Message message, int freelancerId, int employerId);
        Task<MessageResponse> GetByIdAndFreelancerIdAndEmployerIdAsync(int id, int freelancerId, int employerId);
    }
}
