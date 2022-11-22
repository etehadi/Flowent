using Flowent.Sample.MediatR.LeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace Flowent.Sample.MediatR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;

public class GetLeaveTypeDetailRequest : IRequest<LeaveTypeDto>
{
    public int Id { get; set; }
}