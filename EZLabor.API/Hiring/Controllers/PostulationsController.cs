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

    public class PostulationsController: ControllerBase
    {
        private readonly IPostulationService _postulationService;
        private readonly IMapper _mapper;

        public PostulationsController(IPostulationService postulationService, IMapper mapper)
        {
            _postulationService = postulationService;
            _mapper = mapper;
        }


        [SwaggerOperation(
            Summary = "List all postulations",
            Description = "List of postulations",
            OperationId = "ListAllPostulations")]
        [SwaggerResponse(200, "List of Postulations", typeof(IEnumerable<PostulationResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PostulationResource>), 200)]
        public async Task<IEnumerable<PostulationResource>> GetAllAsync()
        {
            var postulations = await _postulationService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Postulation>, IEnumerable<PostulationResource>>(postulations);
            return resources;
        }

        [SwaggerOperation(
            Summary = "Get postulation",
            Description = "Get a postulation by Id",
            OperationId = "GetPostulation")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PostulationResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _postulationService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var postulationResource = _mapper.Map<Postulation, PostulationResource>(result.Resource);
            return Ok(postulationResource);
        }


        [SwaggerOperation(
            Summary = "Post postulation",
            Description = "Post a new postulation",
            OperationId = "postPostulation")]
        [HttpPost]
        [ProducesResponseType(typeof(PostulationResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SavePostulationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var postulation = _mapper.Map<SavePostulationResource, Postulation>(resource);
            var result = await _postulationService.SaveAsync(postulation);

            if (!result.Success)
                return BadRequest(result.Message);

            var postulationResource = _mapper.Map<Postulation, PostulationResource>(result.Resource);
            return Ok(postulationResource);
        }

        [SwaggerOperation(
            Summary = "Update postulation",
            Description = "Update a postulation",
            OperationId = "UpdatePostulation")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PostulationResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePostulationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var postulation = _mapper.Map<SavePostulationResource, Postulation>(resource);
            var result = await _postulationService.UpdateAsync(id, postulation);

            if (!result.Success)
                return BadRequest(result.Message);

            var postulationResource = _mapper.Map<Postulation, PostulationResource>(result.Resource);
            return Ok(postulationResource);
        }

        [SwaggerOperation(
            Summary = "Delete postulation",
            Description = "Delete a postulation",
            OperationId = "DeletePostulation")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PostulationResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _postulationService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var postulationResource = _mapper.Map<Postulation, PostulationResource>(result.Resource);
            return Ok(postulationResource);
        }





    }
}
