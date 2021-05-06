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
    public class KnowledgesController: ControllerBase
    {
        private readonly IKnowledgeService _knowledgeService;
        private readonly IMapper _mapper;

        public KnowledgesController(IKnowledgeService knowledgeService, IMapper mapper)
        {
            _knowledgeService = knowledgeService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all knowledges",
            Description = "List of Knowledges",
            OperationId = "ListAllKnowledges")]
        [SwaggerResponse(200, "List of Knowledges", typeof(IEnumerable<KnowledgeResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<KnowledgeResource>), 200)]
        public async Task<IEnumerable<KnowledgeResource>> GetAllAsync()
        {
            var knowledges = await _knowledgeService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Knowledge>, IEnumerable<KnowledgeResource>>(knowledges);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(KnowledgeResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _knowledgeService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var knowledgeResource = _mapper.Map<Knowledge, KnowledgeResource>(result.Resource);
            return Ok(knowledgeResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(KnowledgeResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveKnowledgeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var knowledge = _mapper.Map<SaveKnowledgeResource, Knowledge>(resource);
            var result = await _knowledgeService.SaveAsync(knowledge);

            if (!result.Success)
                return BadRequest(result.Message);

            var knowledgeResource = _mapper.Map<Knowledge, KnowledgeResource>(result.Resource);
            return Ok(knowledgeResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(KnowledgeResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveKnowledgeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var knowledge = _mapper.Map<SaveKnowledgeResource, Knowledge>(resource);
            var result = await _knowledgeService.UpdateAsync(id, knowledge);

            if (!result.Success)
                return BadRequest(result.Message);

            var knowledgeResource = _mapper.Map<Knowledge, KnowledgeResource>(result.Resource);
            return Ok(knowledgeResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(KnowledgeResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _knowledgeService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var knowledgeResource = _mapper.Map<Knowledge, KnowledgeResource>(result.Resource);
            return Ok(knowledgeResource);
        }
    }
}
