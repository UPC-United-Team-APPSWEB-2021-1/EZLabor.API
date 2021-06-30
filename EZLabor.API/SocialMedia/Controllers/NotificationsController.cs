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
    public class NotificationsController: ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationsController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [SwaggerOperation(
           Summary = "List all notifications",
           Description = "List of notifications",
           OperationId = "ListAllNotifications")]
        [SwaggerResponse(200, "List of Notifications", typeof(IEnumerable<NotificationResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<NotificationResource>), 200)]
        public async Task<IEnumerable<NotificationResource>> GetAllAsync()
        {
            var notifications = await _notificationService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Notification>, IEnumerable<NotificationResource>>(notifications);
            return resources;
        }
        [SwaggerOperation(
            Summary = "Get notification",
            Description = "Get a Notification by Id",
            OperationId = "GetNotification")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(NotificationResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _notificationService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var notificationResource = _mapper.Map<Notification, NotificationResource>(result.Resource);
            return Ok(notificationResource);
        }


        [SwaggerOperation(
            Summary = "Post notification",
            Description = "Post a new notification",
            OperationId = "postNotification")]
        [HttpPost]
        [ProducesResponseType(typeof(NotificationResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveNotificationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var notification = _mapper.Map<SaveNotificationResource, Notification>(resource);
            var result = await _notificationService.SaveAsync(notification);

            if (!result.Success)
                return BadRequest(result.Message);

            var notificationResource = _mapper.Map<Notification, NotificationResource>(result.Resource);
            return Ok(notificationResource);
        }

        [SwaggerOperation(
            Summary = "Update notification",
            Description = "Update a notification",
            OperationId = "UpdateNotification")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(NotificationResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveNotificationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var notification = _mapper.Map<SaveNotificationResource, Notification>(resource);
            var result = await _notificationService.UpdateAsync(id, notification);

            if (!result.Success)
                return BadRequest(result.Message);

            var notificationResource = _mapper.Map<Notification, NotificationResource>(result.Resource);
            return Ok(notificationResource);
        }

        [SwaggerOperation(
            Summary = "Delete notification",
            Description = "Delete a notification",
            OperationId = "DeleteNotification")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(NotificationResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _notificationService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var notificationResource = _mapper.Map<Notification, NotificationResource>(result.Resource);
            return Ok(notificationResource);
        }
    }
}
