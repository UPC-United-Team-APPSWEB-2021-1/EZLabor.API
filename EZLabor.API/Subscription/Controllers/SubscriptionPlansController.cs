using AutoMapper;
using EZLabor.API.Extensions;
using EZLabor.API.Subscription.Domain.Model;
using EZLabor.API.Subscription.Domain.Services;
using EZLabor.API.Subscription.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Subscription.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class SubscriptionPlansController : ControllerBase
    {
        private readonly ISubscriptionPlanService _subscriptionPlanService;
        private readonly IMapper _mapper;
        public SubscriptionPlansController(ISubscriptionPlanService subscriptionPlanService, IMapper mapper)
        {
            _subscriptionPlanService = subscriptionPlanService;
            _mapper = mapper;
        }


        [SwaggerOperation(
            Summary = "List all subscription plans",
            Description = "List of subscription plans",
            OperationId = "ListAllSubscriptionPlans")]
        [SwaggerResponse(200, "List of subscription plans", typeof(IEnumerable<SubscriptionPlanResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SubscriptionPlanResource>), 200)]
        public async Task<IEnumerable<SubscriptionPlanResource>> GetAllAsync()
        {
            var subscriptionPlan = await _subscriptionPlanService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<SubscriptionPlan>, IEnumerable<SubscriptionPlanResource>>(subscriptionPlan);
            return resources;
        }

        [SwaggerOperation(
            Summary = "Post subscriptionPlan",
            Description = "Post a subscriptionPlan",
            OperationId = "Post subscriptionPlan")]
        [HttpPost]
        [ProducesResponseType(typeof(SubscriptionPlanResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveSubscriptionPlanResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var subscriptionPlan = _mapper.Map<SaveSubscriptionPlanResource, SubscriptionPlan>(resource);
            var result = await _subscriptionPlanService.SaveAsync(subscriptionPlan);

            if (!result.Success)
                return BadRequest(result.Message);

            var subscriptionPlanResource = _mapper.Map<SubscriptionPlan, SubscriptionPlanResource>(result.Resource);
            return Ok(subscriptionPlanResource);
        }

        [SwaggerOperation(
            Summary = "Update subscriptionPlan",
            Description = "Update a subscriptionPlan",
            OperationId = "Update subscriptionPlan")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SubscriptionPlanResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSubscriptionPlanResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var subscriptionPlan = _mapper.Map<SaveSubscriptionPlanResource, SubscriptionPlan>(resource);
            var result = await _subscriptionPlanService.UpdateAsync(id, subscriptionPlan);

            if (!result.Success)
                return BadRequest(result.Message);

            var subscriptionPlanResource = _mapper.Map<SubscriptionPlan, SubscriptionPlanResource>(result.Resource);
            return Ok(subscriptionPlanResource);
        }

        [SwaggerOperation(
            Summary = "Delete subscriptionPlan",
            Description = "Delete a subscriptionPlan",
            OperationId = "Delete subscriptionPlan")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SubscriptionPlanResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _subscriptionPlanService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var subscriptionPlanResource = _mapper.Map<SubscriptionPlan, SubscriptionPlanResource>(result.Resource);
            return Ok(subscriptionPlanResource);
        }

        [SwaggerOperation(
            Summary = "Get subscriptionPlan",
            Description = "Get a subscriptionPlan",
            OperationId = "Get subscriptionPlan")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SubscriptionPlanResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _subscriptionPlanService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var subscriptionPlanResource = _mapper.Map<SubscriptionPlan, SubscriptionPlanResource>(result.Resource);
            return Ok(subscriptionPlanResource);
        }

    }
}
