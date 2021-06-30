
using EZLabor.API.Domain.Services.Communications;
using EZLabor.API.SocialMedia.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Domain.Services.Communications
{
    public class CommentResponse: BaseResponse<Comment>
    {
        public CommentResponse(Comment resource) : base(resource)
        {
        }

        public CommentResponse(string message) : base(message)
        {
        }
    }
}
