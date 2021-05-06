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
    public class EmployersController: ControllerBase
    {
        private readonly IEmployerService _employerService;
        private readonly IMapper _mapper;

        public EmployersController(IEmployerService employerService, IMapper mapper)
        {
            _employerService = employerService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all employers",
            Description = "List of Employers",
            OperationId = "ListAllEmployers")]
        [SwaggerResponse(200, "List of Employers", typeof(IEnumerable<EmployerResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EmployerResource>), 200)]
        public async Task<IEnumerable<EmployerResource>> GetAllAsync()
        {
            var employers = await _employerService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Employer>, IEnumerable<EmployerResource>>(employers);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmployerResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _employerService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var employerResource = _mapper.Map<Employer, EmployerResource>(result.Resource);
            return Ok(employerResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(EmployerResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveEmployerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var employer = _mapper.Map<SaveEmployerResource, Employer>(resource);
            var result = await _employerService.SaveAsync(employer);

            if (!result.Success)
                return BadRequest(result.Message);

            var employerResource = _mapper.Map<Employer, EmployerResource>(result.Resource);
            return Ok(employerResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EmployerResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveEmployerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var employer = _mapper.Map<SaveEmployerResource, Employer>(resource);
            var result = await _employerService.UpdateAsync(id, employer);

            if (!result.Success)
                return BadRequest(result.Message);

            var employerResource = _mapper.Map<Employer, EmployerResource>(result.Resource);
            return Ok(employerResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EmployerResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _employerService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var employerResource = _mapper.Map<Employer, EmployerResource>(result.Resource);
            return Ok(employerResource);
        }

    }
}
