using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Domain.Models
{
    public enum EMoneyType: byte
    {
        [Description("S/.")]
        PEN = 1,
        [Description("$")]
        USD = 2,
        [Description("€")]
        EUR = 3
    }
}
