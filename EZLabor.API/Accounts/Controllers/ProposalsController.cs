using AutoMapper;
using EZLabor.API.Domain.Models;
using EZLabor.API.Domain.Services;
using EZLabor.API.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Controllers
{
    [ApiController]
    [Route("/api/freelancers/{freelancerId}")]
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


        [SwaggerOperation(
            Summary = "Get proposals",
            Description = "Get Proposals by FreelancerId",
            OperationId = "GetProposals")]
        [HttpGet]
        public async Task<IEnumerable<EmployerResource>> GetAllByFreelancerIdAsync(int freelancerId)
        {
            var employers = await _employerService.ListByFreelancerId(freelancerId);
            var resources = _mapper.Map<IEnumerable<Employer>, IEnumerable<EmployerResource>>(employers);
            return resources;
        }

        [SwaggerOperation(
            Summary = "Post proposal",
            Description = "Post Proposal",
            OperationId = "PostProposal")]
        [HttpPost("employer/{employerId}")]
        public async Task<IActionResult> AssignProposal(int employerId, int freelancerId)
        {
            var result = await _proposalService.AssignProposalAsync(employerId, freelancerId);
            if (!result.Success)
                return BadRequest(result.Message);

            var employerResource = _mapper.Map<Employer, EmployerResource>(result.Resource.Employer);
            return Ok(employerResource);

        }

        [SwaggerOperation(
            Summary = "Delete proposals",
            Description = "Delete an Proposal",
            OperationId = "DeleteProposal")]
        [HttpDelete("employer/{employerId}")]
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
