using AutoMapper;
using EZLabor.API.Domain.Models;
using EZLabor.API.Domain.Services;
using EZLabor.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Controllers
{
    [ApiController]
    [Route("/api/freelancers/{freelancerId}/skills")]
    [Produces("application/json")]
    public class ProposalsController: ControllerBase
    {
        private readonly IEmployerService _employerService;
        private readonly IProposalService _proposalService;
        private readonly IMapper _mapper;

        public ProposalsController(IEmployerService employerService, IProposalService proposalService, IMapper mapper)
        {
            _employerService = employerService;
            _proposalService = proposalService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployerResource>> GetAllByProductIdAsync(int freelancerId)
        {
            var employers = await _employerService.ListByFreelancerId(freelancerId);
            var resources = _mapper.Map<IEnumerable<Employer>, IEnumerable<EmployerResource>>(employers);
            return resources;
        }

        [HttpPost("{proposalId}")]
        public async Task<IActionResult> AssignProposal(int employerId, int freelancerId)
        {
            var result = await _proposalService.AssignProposalAsync(employerId, freelancerId);
            if (!result.Success)
                return BadRequest(result.Message);

            var employerResource = _mapper.Map<Employer, EmployerResource>(result.Resource.Employer);
            return Ok(employerResource);

        }

        [HttpDelete("{proposalId}")]
        public async Task<IActionResult> UnassignProposal(int employerId, int freelancerId)
        {
            var result = await _proposalService.UnassignProposalAsync(employerId, freelancerId);
            if (!result.Success)
                return BadRequest(result.Message);

            var employerResource = _mapper.Map<Employer, EmployerResource>(result.Resource.Employer);
            return Ok(employerResource);

        }
    }
}
