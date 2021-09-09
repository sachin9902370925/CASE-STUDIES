using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums
{
    public enum status
    {
        Scheduled,
        InProgress,
        OnHold,
        Completed,
        Cancelled
    }

    public enum priority
    {
        High,
        Medium,
        Low
    }
}
