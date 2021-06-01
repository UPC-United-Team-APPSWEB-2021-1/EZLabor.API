using EZLabor.API.Domain.Persistence.Repositories;
using EZLabor.API.Hiring.Domain.Model;
using EZLabor.API.Hiring.Domain.Persistence.Repositories;
using EZLabor.API.Hiring.Domain.Services;
using EZLabor.API.Hiring.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Services
{
    public class MeetingService: IMeetingService
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IUnitOfWork _unitOfWork;
   

       
        public MeetingService(IMeetingRepository meetingRepository, IUnitOfWork unitOfWork)
        {
            _meetingRepository = meetingRepository;
            _unitOfWork = unitOfWork;
            
        }

        public async Task<IEnumerable<Meeting>> ListAsync()
        {
            return await _meetingRepository.ListAsync();
        }

        public async Task<IEnumerable<Meeting>> ListByPostulationIdAsync(int postulationId)
        {
            return await _meetingRepository.ListByPostulationIdAsync(postulationId);

        }

        public async Task<MeetingResponse> GetByIdAsync(int id)
        {
            var existingMeeting = await _meetingRepository.FindById(id);

            if (existingMeeting == null)
                return new MeetingResponse("Meeting not found");
            return new MeetingResponse(existingMeeting);
        }
        public async Task<MeetingResponse> SaveAsync(Meeting meeting)
        {
            try
            {
                await _meetingRepository.AddAsync(meeting);
                await _unitOfWork.CompleteAsync();

                return new MeetingResponse(meeting);
            }
            catch(Exception ex)
            {
                return new MeetingResponse($"An error ocurred while saving the meeting: {ex.Message}");
            }
        }
        public async Task<MeetingResponse> UpdateAsync(int id, Meeting meeting)
        {
            var existingMeeting = await _meetingRepository.FindById(id);

            if (existingMeeting == null)
                return new MeetingResponse("Meeting not found");

            try
            {
                _meetingRepository.Update(existingMeeting);
                await _unitOfWork.CompleteAsync();
                return new MeetingResponse(existingMeeting);
            }
            catch (Exception ex)
            {
                return new MeetingResponse($"An error ocurred while updating the meeting: {ex.Message}");
            }

        }

        public async Task<MeetingResponse> DeleteAsync(int id)
        {
            var existingMeeting = await _meetingRepository.FindById(id);
            if (existingMeeting == null)
                return new MeetingResponse("Meeting not found");
            try
            {
                _meetingRepository.Remove(existingMeeting);
                await _unitOfWork.CompleteAsync();
                return new MeetingResponse(existingMeeting);
            }
            catch (Exception ex)
            {
                return new MeetingResponse($"An error ocurred while deleting the meeting: {ex.Message}");
            }

        }


    }
}
