using EZLabor.API.Domain.Persistence.Repositories;
using EZLabor.API.Messaging.Domain.Model;
using EZLabor.API.Messaging.Domain.Persistence.Repositories;
using EZLabor.API.Messaging.Domain.Services;
using EZLabor.API.Messaging.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Messaging.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IFreelancerRepository _freelancerRepository;
        private readonly IEmployerRepository _employerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MessageService(IMessageRepository messageRepository, IFreelancerRepository freelancerRepository, IEmployerRepository employerRepository, IUnitOfWork unitOfWork)
        {
            _messageRepository = messageRepository;
            _freelancerRepository = freelancerRepository;
            _employerRepository = employerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Message>> ListAsync()
        {
            return await _messageRepository.ListAsync();
        }

        public async Task<IEnumerable<Message>> ListByEmployerIdAsync(int employerId)
        {
            return await _messageRepository.ListByEmployerIdAsync(employerId);
        }

        public async Task<IEnumerable<Message>> ListByFreelancerIdAsync(int freelancerId)
        {
            return await _messageRepository.ListByFreelancerIdAsync(freelancerId);
        }

        public async Task<MessageResponse> SaveAsync(Message message, int freelancerId, int employerId)
        {
            try
            {
                await _messageRepository.AddAsync(message);
                await _unitOfWork.CompleteAsync();

                return new MessageResponse(message);
            }
            catch (Exception ex)
            {
                return new MessageResponse($"An error ocurred while saving the message: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Message>> ListByFreelancerIdAndEmployerIdAsync(int freelancerId, int employerId)
        {
            return await _messageRepository.ListByFreelancerIdAndEmployerIdAsync(freelancerId, employerId);
        }
        public async Task<MessageResponse> GetByIdAndFreelancerIdAndEmployerIdAsync(int id, int freelancerId, int employerId)
        {
            var existingMessage = await _messageRepository.FindByIdAndFreelancerIdAndEmployerId(id, freelancerId, employerId);

            if (existingMessage == null)
                return new MessageResponse("Message not found");
            return new MessageResponse(existingMessage);
        }
    }
}
