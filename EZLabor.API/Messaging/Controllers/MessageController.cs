using AutoMapper;
using EZLabor.API.Extensions;
using EZLabor.API.Messaging.Domain.Model;
using EZLabor.API.Messaging.Domain.Services;
using EZLabor.API.Messaging.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Messaging.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessagesController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all messages",
            Description = "List of messages",
            OperationId = "ListAllMessages")]
        [SwaggerResponse(200, "List of Messages", typeof(IEnumerable<MessageResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MessageResource>), 200)]
        public async Task<IEnumerable<MessageResource>> GetAllAsync()
        {
            var messages = await _messageService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Message>, IEnumerable<MessageResource>>(messages);
            return resources;
        }

        [SwaggerOperation(
            Summary = "Post message",
            Description = "Post a messages",
            OperationId = "Post Message")]
        [HttpPost]
        [ProducesResponseType(typeof(MessageResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveMessageResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var message = _mapper.Map<SaveMessageResource, Message>(resource);
            var result = await _messageService.SaveAsync(message, message.FreelancerId, message.EmployerId);

            if (!result.Success)
                return BadRequest(result.Message);

            var messageResource = _mapper.Map<Message, MessageResource>(result.Resource);
            return Ok(messageResource);
        }

        [SwaggerOperation(
            Summary = "List all messages by freelancer id",
            Description = "List all messages by freelancer id",
            OperationId = "ListByFreelancerIdAsync")]
        [SwaggerResponse(200, "List of Messages by freelancer id", typeof(IEnumerable<MessageResource>))]
        [HttpGet("freelancer/{freelancerId}")]
        [ProducesResponseType(typeof(IEnumerable<MessageResource>), 200)]
        public async Task<IEnumerable<MessageResource>> ListByFreelancerIdAsync(int freelancerId)
        {
            var messages = await _messageService.ListByFreelancerIdAsync(freelancerId);
            var resources = _mapper
                .Map<IEnumerable<Message>, IEnumerable<MessageResource>>(messages);
            return resources;
        }


        [SwaggerOperation(
            Summary = "List all messages by employer id",
            Description = "List all messages by employer id",
            OperationId = "ListByEmployerIdAsync")]
        [SwaggerResponse(200, "List of Messages by employer id", typeof(IEnumerable<MessageResource>))]
        [HttpGet("employer/{employerId}")]
        [ProducesResponseType(typeof(IEnumerable<MessageResource>), 200)]
        public async Task<IEnumerable<MessageResource>> ListByEmployerIdAsync(int employerId)
        {
            var messages = await _messageService.ListByEmployerIdAsync(employerId);
            var resources = _mapper
                .Map<IEnumerable<Message>, IEnumerable<MessageResource>>(messages);
            return resources;
        }



        [SwaggerOperation(
            Summary = "List all messages by employer id and freelancer id",
            Description = "List all messages by employer id and freelancer id",
            OperationId = "ListByFreelancerIdAndEmployerIdAsync")]
        [SwaggerResponse(200, "List of Messages by employer id and freelancer id", typeof(IEnumerable<MessageResource>))]
        [HttpGet("freelancer/{freelancerId}/employer/{employerId}")]
        [ProducesResponseType(typeof(IEnumerable<MessageResource>), 200)]
        public async Task<IEnumerable<MessageResource>> ListByFreelancerIdAndEmployerIdAsync(int freelancerId, int employerId)
        {
            var messages = await _messageService.ListByFreelancerIdAndEmployerIdAsync(freelancerId, employerId);
            var resources = _mapper
                .Map<IEnumerable<Message>, IEnumerable<MessageResource>>(messages);
            return resources;
        }

        [SwaggerOperation(
            Summary = "List all messages by id, by freelancer id and employer id",
            Description = "List all messages by id, by freelancer id and employer id",
            OperationId = "ListByIdFreelancerIdandEmployerIdAsync")]
        [HttpGet("{id}/freelancer/{freelancerId}/employer/{employerId}")]
        [ProducesResponseType(typeof(MessageResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetByIdAndFreelancerIdAndEmployerIdAsync(int id, int freelancerId, int employerId)
        {
            var result = await _messageService.GetByIdAndFreelancerIdAndEmployerIdAsync(id, freelancerId, employerId);
            if (!result.Success)
                return BadRequest(result.Message);
            var messageResource = _mapper.Map<Message, MessageResource>(result.Resource);
            return Ok(messageResource);
        }
    }
}
