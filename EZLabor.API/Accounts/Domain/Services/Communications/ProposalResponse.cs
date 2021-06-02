using EZLabor.API.Accounts.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Accounts.Domain.Services.Communications
{
    public class ProposalResponse: BaseResponse<Proposal>
    {
        public ProposalResponse(Proposal resource) : base(resource)
        {
        }

        public ProposalResponse(string message) : base(message)
        {
        }
    }
}
