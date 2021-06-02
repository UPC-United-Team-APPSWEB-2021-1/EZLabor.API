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
    public class CommentsController: ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentsController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [SwaggerOperation(
           Summary = "List all comments",
           Description = "List of comments",
           OperationId = "ListAllComments")]
        [SwaggerResponse(200, "List of Comments", typeof(IEnumerable<CommentResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CommentResource>), 200)]
        public async Task<IEnumerable<CommentResource>> GetAllAsync()
        {
            var comments = await _commentService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Comment>, IEnumerable<CommentResource>>(comments);
            return resources;
        }
        [SwaggerOperation(
            Summary = "Get comment",
            Description = "Get a Comment by Id",
            OperationId = "GetComment")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CommentResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _commentService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var commentResource = _mapper.Map<Comment, CommentResource>(result.Resource);
            return Ok(commentResource);
        }


        [SwaggerOperation(
            Summary = "Post comment",
            Description = "Post a new comment",
            OperationId = "postComment")]
        [HttpPost]
        [ProducesResponseType(typeof(CommentResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveCommentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var comment = _mapper.Map<SaveCommentResource, Comment>(resource);
            var result = await _commentService.SaveAsync(comment);

            if (!result.Success)
                return BadRequest(result.Message);

            var commentResource = _mapper.Map<Comment, CommentResource>(result.Resource);
            return Ok(commentResource);
        }

        [SwaggerOperation(
            Summary = "Update comment",
            Description = "Update a comment",
            OperationId = "UpdateComment")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CommentResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCommentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var comment = _mapper.Map<SaveCommentResource, Comment>(resource);
            var result = await _commentService.UpdateAsync(id, comment);

            if (!result.Success)
                return BadRequest(result.Message);

            var commentResource = _mapper.Map<Comment, CommentResource>(result.Resource);
            return Ok(commentResource);
        }

        [SwaggerOperation(
            Summary = "Delete comment",
            Description = "Delete a comment",
            OperationId = "DeleteComment")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CommentResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _commentService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var commentResource = _mapper.Map<Comment, CommentResource>(result.Resource);
            return Ok(commentResource);
        }
    }
}
