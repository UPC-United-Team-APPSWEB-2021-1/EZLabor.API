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
    public class OffersController: ControllerBase
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;

        public OffersController(IOfferService offerService, IMapper mapper)
        {
            _offerService = offerService;
            _mapper = mapper;
        }


        [SwaggerOperation(
            Summary = "List all offers",
            Description = "List of offers",
            OperationId = "ListAllOffers")]
        [SwaggerResponse(200, "List of Offers", typeof(IEnumerable<OfferResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OfferResource>), 200)]
        public async Task<IEnumerable<OfferResource>> GetAllAsync()
        {
            var offers = await _offerService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Offer>, IEnumerable<OfferResource>>(offers);
            return resources;
        }


        [SwaggerOperation(
            Summary = "Get offer",
            Description = "Get an Offer by Id",
            OperationId = "GetOffer")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OfferResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _offerService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var offerResource = _mapper.Map<Offer, OfferResource>(result.Resource);
            return Ok(offerResource);
        }


        [SwaggerOperation(
            Summary = "Post offer",
            Description = "Post a new offer",
            OperationId = "postOffer")]
        [HttpPost]
        [ProducesResponseType(typeof(OfferResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveOfferResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var offer = _mapper.Map<SaveOfferResource, Offer>(resource);
            var result = await _offerService.SaveAsync(offer);

            if (!result.Success)
                return BadRequest(result.Message);

            var offerResource = _mapper.Map<Offer, OfferResource>(result.Resource);
            return Ok(offerResource);
        }


        [SwaggerOperation(
            Summary = "Update offer",
            Description = "Update an offer",
            OperationId = "updateOffer")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(OfferResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveOfferResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var offer = _mapper.Map<SaveOfferResource, Offer>(resource);
            var result = await _offerService.UpdateAsync(id, offer);

            if (!result.Success)
                return BadRequest(result.Message);

            var offerResource = _mapper.Map<Offer, OfferResource>(result.Resource);
            return Ok(offerResource);
        }

        [SwaggerOperation(
            Summary = "Delete offer",
            Description = "Delete an offer",
            OperationId = "DeleteOffer")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(OfferResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _offerService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var offerResource = _mapper.Map<Offer, OfferResource>(result.Resource);
            return Ok(offerResource);
        }




    }
}
