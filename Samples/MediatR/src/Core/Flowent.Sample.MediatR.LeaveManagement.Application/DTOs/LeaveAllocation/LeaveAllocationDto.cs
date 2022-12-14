using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flowent.Sample.MediatR.LeaveManagement.Application.DTOs.Common;
using Flowent.Sample.MediatR.LeaveManagement.Application.DTOs.LeaveType;

namespace Flowent.Sample.MediatR.LeaveManagement.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
