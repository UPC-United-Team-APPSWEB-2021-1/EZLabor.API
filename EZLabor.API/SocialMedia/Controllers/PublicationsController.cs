using AutoMapper;
using EZLabor.API.Accounts.Extensions;
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
    public class PublicationsController: ControllerBase
    {
        private readonly IPublicationService _publicationService;
        private readonly IMapper _mapper;

        public PublicationsController(IPublicationService publicationService, IMapper mapper)
        {
            _publicationService = publicationService;
            _mapper = mapper;
        }

        [SwaggerOperation(
           Summary = "List all publications",
           Description = "List of publications",
           OperationId = "ListAllPublications")]
        [SwaggerResponse(200, "List of Publications", typeof(IEnumerable<PublicationResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PublicationResource>), 200)]
        public async Task<IEnumerable<PublicationResource>> GetAllAsync()
        {
            var publications = await _publicationService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Publication>, IEnumerable<PublicationResource>>(publications);
            return resources;
        }
        [SwaggerOperation(
            Summary = "Get publication",
            Description = "Get a Publication by Id",
            OperationId = "GetPublication")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PublicationResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _publicationService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var publicationResource = _mapper.Map<Publication, PublicationResource>(result.Resource);
            return Ok(publicationResource);
        }


        [SwaggerOperation(
            Summary = "Post publication",
            Description = "Post a new publication",
            OperationId = "postPublication")]
        [HttpPost]
        [ProducesResponseType(typeof(PublicationResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SavePublicationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var publication = _mapper.Map<SavePublicationResource, Publication>(resource);
            var result = await _publicationService.SaveAsync(publication);

            if (!result.Success)
                return BadRequest(result.Message);

            var publicationResource = _mapper.Map<Publication, PublicationResource>(result.Resource);
            return Ok(publicationResource);
        }

        [SwaggerOperation(
            Summary = "Update publication",
            Description = "Update a publication",
            OperationId = "UpdatePublication")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PublicationResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePublicationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var publication = _mapper.Map<SavePublicationResource, Publication>(resource);
            var result = await _publicationService.UpdateAsync(id, publication);

            if (!result.Success)
                return BadRequest(result.Message);

            var publicationResource = _mapper.Map<Publication, PublicationResource>(result.Resource);
            return Ok(publicationResource);
        }

        [SwaggerOperation(
            Summary = "Delete publication",
            Description = "Delete a publication",
            OperationId = "DeletePublication")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PublicationResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _publicationService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var publicationResource = _mapper.Map<Publication, PublicationResource>(result.Resource);
            return Ok(publicationResource);
        }
    }
}
