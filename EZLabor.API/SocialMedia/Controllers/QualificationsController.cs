using AutoMapper;
using EZLabor.API.Extensions;
using EZLabor.API.SocialMedia.Domain.Model;
using EZLabor.API.SocialMedia.Domain.Services;
using EZLabor.API.SocialMedia.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class QualificationsController: ControllerBase
    {
        private readonly IQualificationService _qualificationService;
        private readonly IMapper _mapper;

        public QualificationsController(IQualificationService qualificationService, IMapper mapper)
        {
            _qualificationService = qualificationService;
            _mapper = mapper;
        }

        [SwaggerOperation(
           Summary = "List all qualifications",
           Description = "List of qualifications",
           OperationId = "ListAllQualifications")]
        [SwaggerResponse(200, "List of Qualifications", typeof(IEnumerable<QualificationResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<QualificationResource>), 200)]
        public async Task<IEnumerable<QualificationResource>> GetAllAsync()
        {
            var qualifications = await _qualificationService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Qualification>, IEnumerable<QualificationResource>>(qualifications);
            return resources;
        }
        [SwaggerOperation(
            Summary = "Get qualification",
            Description = "Get a Qualification by Id",
            OperationId = "GetQualification")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(QualificationResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _qualificationService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var qualificationResource = _mapper.Map<Qualification, QualificationResource>(result.Resource);
            return Ok(qualificationResource);
        }


        [SwaggerOperation(
            Summary = "Post qualification",
            Description = "Post a new qualification",
            OperationId = "postQualification")]
        [HttpPost]
        [ProducesResponseType(typeof(QualificationResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveQualificationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var qualification = _mapper.Map<SaveQualificationResource, Qualification>(resource);
            var result = await _qualificationService.SaveAsync(qualification);

            if (!result.Success)
                return BadRequest(result.Message);

            var qualificationResource = _mapper.Map<Qualification, QualificationResource>(result.Resource);
            return Ok(qualificationResource);
        }

        [SwaggerOperation(
            Summary = "Update qualification",
            Description = "Update a qualification",
            OperationId = "UpdateQualification")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(QualificationResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveQualificationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var qualification = _mapper.Map<SaveQualificationResource, Qualification>(resource);
            var result = await _qualificationService.UpdateAsync(id, qualification);

            if (!result.Success)
                return BadRequest(result.Message);

            var qualificationResource = _mapper.Map<Qualification, QualificationResource>(result.Resource);
            return Ok(qualificationResource);
        }

        [SwaggerOperation(
            Summary = "Delete qualification",
            Description = "Delete a qualification",
            OperationId = "DeleteQualification")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(QualificationResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _qualificationService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var qualificationResource = _mapper.Map<Qualification, QualificationResource>(result.Resource);
            return Ok(qualificationResource);
        }
    }
}
