using Flowent.Sample.MediatR.LeaveManagement.Application.DTOs.LeaveRequest;
using Flowent.Sample.MediatR.LeaveManagement.Application.Responses;
using MediatR;

namespace Flowent.Sample.MediatR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand :IRequest<BaseCommandResponse>
    {
        public LeaveRequestDto  LeaveRequestDto { get; set; }
    }
}
