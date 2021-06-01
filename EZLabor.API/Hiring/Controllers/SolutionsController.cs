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
    public class SolutionsController:ControllerBase
    {

        private readonly ISolutionService _solutionService;
        private readonly IMapper _mapper;

        public SolutionsController(ISolutionService solutionService, IMapper mapper)
        {
            _solutionService = solutionService;
            _mapper = mapper;
        }


        [SwaggerOperation(
            Summary = "List all solutions",
            Description = "List of solutions",
            OperationId = "ListAllSolutions")]
        [SwaggerResponse(200, "List of Solutions", typeof(IEnumerable<SolutionResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SolutionResource>), 200)]
        public async Task<IEnumerable<SolutionResource>> GetAllAsync()
        {
            var solutions = await _solutionService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Solution>, IEnumerable<SolutionResource>>(solutions);
            return resources;
        }

        [SwaggerOperation(
            Summary = "Get solution",
            Description = "Get a solution by Id",
            OperationId = "GetSolution")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SolutionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _solutionService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var solutionResource = _mapper.Map<Solution, SolutionResource>(result.Resource);
            return Ok(solutionResource);
        }


        [SwaggerOperation(
            Summary = "Post solution",
            Description = "Post a new solution",
            OperationId = "postSolution")]
        [HttpPost]
        [ProducesResponseType(typeof(SolutionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveSolutionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var solution = _mapper.Map<SaveSolutionResource, Solution>(resource);
            var result = await _solutionService.SaveAsync(solution);

            if (!result.Success)
                return BadRequest(result.Message);

            var solutionResource = _mapper.Map<Solution, SolutionResource>(result.Resource);
            return Ok(solutionResource);
        }

        [SwaggerOperation(
            Summary = "Update solution",
            Description = "Update a solution",
            OperationId = "UpdateSolution")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SolutionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSolutionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var solution = _mapper.Map<SaveSolutionResource, Solution>(resource);
            var result = await _solutionService.UpdateAsync(id, solution);

            if (!result.Success)
                return BadRequest(result.Message);

            var solutionResource = _mapper.Map<Solution, SolutionResource>(result.Resource);
            return Ok(solutionResource);
        }

        [SwaggerOperation(
            Summary = "Delete solution",
            Description = "Delete a solution",
            OperationId = "DeleteSolution")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SolutionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _solutionService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var solutionResource = _mapper.Map<Solution, SolutionResource>(result.Resource);
            return Ok(solutionResource);
        }







    }
}
