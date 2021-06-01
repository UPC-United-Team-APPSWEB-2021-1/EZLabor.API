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
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;

        public SkillsController(ISkillService skillService, IMapper mapper)
        {
            _skillService = skillService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all skills",
            Description = "List of Skills",
            OperationId = "ListAllSkills")]
        [SwaggerResponse(200, "List of Skills", typeof(IEnumerable<SkillResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SkillResource>), 200)]
        public async Task<IEnumerable<SkillResource>> GetAllAsync()
        {
            var skills = await _skillService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Skill>, IEnumerable<SkillResource>>(skills);
            return resources;
        }

        [SwaggerOperation(
            Summary = "Get skill",
            Description = "Get an Skill by Id",
            OperationId = "GetSkill")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SkillResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _skillService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var skillResource = _mapper.Map<Skill, SkillResource>(result.Resource);
            return Ok(skillResource);
        }


        [SwaggerOperation(
            Summary = "Post skill",
            Description = "Post a new Skill",
            OperationId = "PostSkill")]
        [HttpPost]
        [ProducesResponseType(typeof(SkillResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveSkillResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var skill = _mapper.Map<SaveSkillResource, Skill>(resource);
            var result = await _skillService.SaveAsync(skill);

            if (!result.Success)
                return BadRequest(result.Message);

            var skillResource = _mapper.Map<Skill, SkillResource>(result.Resource);
            return Ok(skillResource);
        }

        [SwaggerOperation(
            Summary = "Update skill",
            Description = "Update an Skill",
            OperationId = "UpdateSkill")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SkillResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSkillResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var skill = _mapper.Map<SaveSkillResource, Skill>(resource);
            var result = await _skillService.UpdateAsync(id, skill);

            if (!result.Success)
                return BadRequest(result.Message);

            var skillResource = _mapper.Map<Skill, SkillResource>(result.Resource);
            return Ok(skillResource);
        }


        [SwaggerOperation(
            Summary = "Delete skill",
            Description = "Delete an Skill",
            OperationId = "DeleteSkill")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SkillResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _skillService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var skillResource = _mapper.Map<Skill, SkillResource>(result.Resource);
            return Ok(skillResource);
        }
    }
}
