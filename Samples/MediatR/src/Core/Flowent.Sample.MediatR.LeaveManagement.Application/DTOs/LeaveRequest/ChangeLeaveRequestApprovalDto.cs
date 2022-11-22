using Flowent.Sample.MediatR.LeaveManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowent.Sample.MediatR.LeaveManagement.Application.DTOs.LeaveRequest
{
    public class ChangeLeaveRequestApprovalDto : BaseDto
    {
        public bool? Approval { get; set; }
    }
}
