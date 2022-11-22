using Flowent.Sample.MediatR.LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowent.Sample.MediatR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class CreateLeaveAllocationCommand : IRequest<int>
    {
        public CreateLeaveAllocationDto LeaveAllocationDto { get; set; }

        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
