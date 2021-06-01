using EZLabor.API.Domain.Models;
using EZLabor.API.Domain.Persistence.Repositories;
using EZLabor.API.Domain.Services;
using EZLabor.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Services
{
    public class ProposalService : IProposalService
    {
        private readonly IProposalRepository _proposalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProposalService(IProposalRepository proposalRepository, IUnitOfWork unitOfWork)
        {
            _proposalRepository = proposalRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProposalResponse> AssignProposalAsync(int employerId, int freelancerId)
        {
            try
            {

                await _proposalRepository.AssignProposal(employerId, freelancerId);
                await _unitOfWork.CompleteAsync();

                Proposal proposal = await _proposalRepository.FindByEmployerIdAndFreelancerId(employerId, freelancerId);

                return new ProposalResponse(proposal);
            }
            catch (Exception ex)
            {
                return new ProposalResponse($"An error ocurred while assigning Freelancer to Employer: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Proposal>> ListAsync()
        {
            return await _proposalRepository.ListAsync();
        }

        public async Task<IEnumerable<Proposal>> ListByEmployerIdAsync(int employerId)
        {
            return await _proposalRepository.ListByEmployerIdAsync(employerId);
        }

        public async Task<IEnumerable<Proposal>> ListByFreelancerIdAsync(int freelancerId)
        {
            return await _proposalRepository.ListByFreelancerIdAsync(freelancerId);
        }

        public async Task<IEnumerable<Proposal>> ListByIdAsync(int Id)
        {
            return await _proposalRepository.ListByIdAsync(Id);
        }

        public async Task<ProposalResponse> UnassignProposalAsync(int employerId, int freelancerId)
        {
            try
            {
                Proposal proposal = await _proposalRepository.FindByEmployerIdAndFreelancerId(employerId, freelancerId);
                _proposalRepository.UnassignProposal(employerId, freelancerId);
                await _unitOfWork.CompleteAsync();

                return new ProposalResponse(proposal);
            }
            catch (Exception ex)
            {
                return new ProposalResponse($"An error ocurred while unassigning Freelancer to Employer: {ex.Message}");
            }
        }
    }
}
