using AutoMapper;
using EZLabor.API.Extensions;
using EZLabor.API.Hiring.Domain.Model;
using EZLabor.API.Hiring.Domain.Services;
using EZLabor.API.Hiring.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class RequirementsController: ControllerBase
    {
        private readonly IRequirementService _requirementService;
        private readonly IMapper _mapper;

        public RequirementsController(IRequirementService requirementService, IMapper mapper)
        {
            _requirementService = requirementService;
            _mapper = mapper;
        }



        [SwaggerOperation(
            Summary = "List all requirements",
            Description = "List of requirements",
            OperationId = "ListAllRequirements")]
        [SwaggerResponse(200, "List of Meetings", typeof(IEnumerable<RequirementResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RequirementResource>), 200)]
        public async Task<IEnumerable<RequirementResource>> GetAllAsync()
        {
            var requirements = await _requirementService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Requirement>, IEnumerable<RequirementResource>>(requirements);
            return resources;
        }

        [SwaggerOperation(
            Summary = "Get requirement",
            Description = "Get a Requirement by Id",
            OperationId = "GetRequirement")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RequirementResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _requirementService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var requirementResource = _mapper.Map<Requirement, RequirementResource>(result.Resource);
            return Ok(requirementResource);
        }


        [SwaggerOperation(
            Summary = "Post requirement",
            Description = "Post a new requirement",
            OperationId = "postRequirement")]
        [HttpPost]
        [ProducesResponseType(typeof(RequirementResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveRequirementResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var requirement = _mapper.Map<SaveRequirementResource, Requirement>(resource);
            var result = await _requirementService.SaveAsync(requirement);

            if (!result.Success)
                return BadRequest(result.Message);

            var requirementResource = _mapper.Map<Requirement, RequirementResource>(result.Resource);
            return Ok(requirementResource);
        }

        [SwaggerOperation(
            Summary = "Update requirement",
            Description = "Update a requirement",
            OperationId = "Updaterequirement")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(RequirementResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRequirementResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var requirement = _mapper.Map<SaveRequirementResource, Requirement>(resource);
            var result = await _requirementService.UpdateAsync(id, requirement);

            if (!result.Success)
                return BadRequest(result.Message);

            var requirementResource = _mapper.Map<Requirement, RequirementResource>(result.Resource);
            return Ok(requirementResource);
        }

        [SwaggerOperation(
            Summary = "Delete requirement",
            Description = "Delete a requirement",
            OperationId = "DeleteRequirement")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RequirementResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _requirementService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var requirementResource = _mapper.Map<Requirement, RequirementResource>(result.Resource);
            return Ok(requirementResource);
        }


    }
}
