using EZLabor.API.Messaging.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Messaging.Domain.Services.Communications
{
    public class MessageResponse : BaseResponse<Message>
    {
        public MessageResponse(Message resource) : base(resource)
        {
        }

        public MessageResponse(string message) : base(message)
        {
        }
    }
}
