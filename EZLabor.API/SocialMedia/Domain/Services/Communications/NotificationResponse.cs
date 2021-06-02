using EZLabor.API.Accounts.Domain.Services.Communications;
using EZLabor.API.SocialMedia.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Domain.Services.Communications
{
    public class NotificationResponse: BaseResponse<Notification>
    {
        public NotificationResponse(Notification resource) : base(resource)
        {
        }

        public NotificationResponse(string message) : base(message)
        {
        }
    }
}
