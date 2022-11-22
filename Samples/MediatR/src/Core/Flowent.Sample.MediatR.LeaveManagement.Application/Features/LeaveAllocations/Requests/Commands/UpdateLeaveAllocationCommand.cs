using Flowent.Sample.MediatR.LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowent.Sample.MediatR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class UpdateLeaveAllocationCommand : IRequest<Unit>
    {
        public LeaveAllocationDto LeaveAllocationDto { get; set; }
    }
}
