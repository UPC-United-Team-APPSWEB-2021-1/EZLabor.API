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

    public class MeetingsController: ControllerBase
    {
        private readonly IMeetingService _meetingService;
        private readonly IMapper _mapper;

        public MeetingsController(IMeetingService meetingService, IMapper mapper)
        {
            _meetingService = meetingService;
            _mapper = mapper;
        }


        [SwaggerOperation(
            Summary = "List all meetings",
            Description = "List of meetings",
            OperationId = "ListAllMeetings")]
        [SwaggerResponse(200, "List of Meetings", typeof(IEnumerable<MeetingResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MeetingResource>), 200)]
        public async Task<IEnumerable<MeetingResource>> GetAllAsync()
        {
            var meetings = await _meetingService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Meeting>, IEnumerable<MeetingResource>>(meetings);
            return resources;
        }

        [SwaggerOperation(
            Summary = "Get meeting",
            Description = "Get a Meeting by Id",
            OperationId = "GetMeeting")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MeetingResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _meetingService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var meetingResource = _mapper.Map<Meeting, MeetingResource>(result.Resource);
            return Ok(meetingResource);
        }


        [SwaggerOperation(
            Summary = "Post meeting",
            Description = "Post a new meeting",
            OperationId = "postMeeting")]
        [HttpPost]
        [ProducesResponseType(typeof(MeetingResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveMeetingResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var meeting = _mapper.Map<SaveMeetingResource, Meeting>(resource);
            var result = await _meetingService.SaveAsync(meeting);

            if (!result.Success)
                return BadRequest(result.Message);

            var meetingResource = _mapper.Map<Meeting, MeetingResource>(result.Resource);
            return Ok(meetingResource);
        }

        [SwaggerOperation(
            Summary = "Update meeting",
            Description = "Update a meeting",
            OperationId = "UpdateMeeting")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(MeetingResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMeetingResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var meeting = _mapper.Map<SaveMeetingResource, Meeting>(resource);
            var result = await _meetingService.UpdateAsync(id, meeting);

            if (!result.Success)
                return BadRequest(result.Message);

            var meetingResource = _mapper.Map<Meeting, MeetingResource>(result.Resource);
            return Ok(meetingResource);
        }

        [SwaggerOperation(
            Summary = "Delete meeting",
            Description = "Delete a meeting",
            OperationId = "DeleteMeeting")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(MeetingResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _meetingService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var meetingResource = _mapper.Map<Meeting, MeetingResource>(result.Resource);
            return Ok(meetingResource);
        }


    }
}
