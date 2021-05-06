using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Domain.Models
{
    public enum EProposalState: byte
    {
        [Description("Cancelled")]
        C = 1,
        [Description("In Progress")]
        IP = 2,
        [Description("Finished")]
        F = 3
    }
}
