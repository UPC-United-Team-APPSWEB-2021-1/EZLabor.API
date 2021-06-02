using EZLabor.API.Accounts.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Accounts.Domain.Services.Communications
{
    public class EmployerResponse: BaseResponse<Employer>
    {
        public EmployerResponse(Employer resource) : base(resource)
        {
        }

        public EmployerResponse(string message) : base(message)
        {
        }
    }
}
