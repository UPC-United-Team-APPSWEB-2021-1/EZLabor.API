using EZLabor.API.Domain.Services.Communications;
using EZLabor.API.Hiring.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Domain.Services.Communications
{
    public class MeetingResponse: BaseResponse<Meeting>
    {
        public MeetingResponse(Meeting resource) : base(resource)
        {

        }

        public MeetingResponse(string message) : base(message)
        {

        }



    }
}
