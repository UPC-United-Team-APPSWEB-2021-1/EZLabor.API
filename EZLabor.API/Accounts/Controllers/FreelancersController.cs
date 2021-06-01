using AutoMapper;
using EZLabor.API.Domain.Models;
using EZLabor.API.Domain.Services;
using EZLabor.API.Extensions;
using EZLabor.API.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FreelancersController: ControllerBase
    {
        private readonly IFreelancerService _freelancerService;
        private readonly IMapper _mapper;

        public FreelancersController(IFreelancerService freelancerService, IMapper mapper)
        {
            _freelancerService = freelancerService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all freelancers",
            Description = "List of Freelancers",
            OperationId = "ListAllFreelancers")]
        [SwaggerResponse(200, "List of Freelancers", typeof(IEnumerable<FreelancerResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FreelancerResource>), 200)]
        public async Task<IEnumerable<FreelancerResource>> GetAllAsync()
        {
            var freelancers = await _freelancerService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Freelancer>, IEnumerable<FreelancerResource>>(freelancers);
            return resources;
        }


        [SwaggerOperation(
            Summary = "Get freelancer",
            Description = "Get an Freelancer by Id",
            OperationId = "GetFreelancer")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FreelancerResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _freelancerService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var freelancerResource = _mapper.Map<Freelancer, FreelancerResource>(result.Resource);
            return Ok(freelancerResource);
        }

        [SwaggerOperation(
            Summary = "Post freelancer",
            Description = "Post a new Freelancer",
            OperationId = "PostFreelancer")]
        [HttpPost]
        [ProducesResponseType(typeof(FreelancerResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveFreelancerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var freelancer = _mapper.Map<SaveFreelancerResource, Freelancer>(resource);
            var result = await _freelancerService.SaveAsync(freelancer);

            if (!result.Success)
                return BadRequest(result.Message);

            var freelancerResource = _mapper.Map<Freelancer, FreelancerResource>(result.Resource);
            return Ok(freelancerResource);
        }

        [SwaggerOperation(
            Summary = "Update freelancer",
            Description = "Update an Freelancer",
            OperationId = "UpdateEmployer")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(FreelancerResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveFreelancerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var freelancer = _mapper.Map<SaveFreelancerResource, Freelancer>(resource);
            var result = await _freelancerService.UpdateAsync(id, freelancer);

            if (!result.Success)
                return BadRequest(result.Message);

            var freelancerResource = _mapper.Map<Freelancer, FreelancerResource>(result.Resource);
            return Ok(freelancerResource);
        }

        [SwaggerOperation(
            Summary = "Delete freelancer",
            Description = "Delete an Freelancer",
            OperationId = "DeleteFreelancer")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(FreelancerResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _freelancerService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var freelancerResource = _mapper.Map<Freelancer, FreelancerResource>(result.Resource);
            return Ok(freelancerResource);
        }
    }
}
