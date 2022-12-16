using AutoMapper;
using Flowent.Sample.MediatR.LeaveManagement.Application.Contracts.Persistence;
using Flowent.Sample.MediatR.LeaveManagement.Application.DTOs.LeaveType;
using Flowent.Sample.MediatR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using MediatR;

namespace Flowent.Sample.MediatR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;

public class GetLeaveTypeDetailRequestHandler : IRequestHandler<GetLeaveTypeDetailRequest, LeaveTypeDto>
{
    private readonly ILeaveAllocationRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public GetLeaveTypeDetailRequestHandler(ILeaveAllocationRepository leaveTypeRepository, IMapper mapper)
    {
        this._leaveTypeRepository = leaveTypeRepository;
        this._mapper = mapper;
    }

    public async Task<LeaveTypeDto> Handle(GetLeaveTypeDetailRequest request, CancellationToken cancellationToken)
    {
        var leaveType = await _leaveTypeRepository.Get(request.Id);
        return _mapper.Map<LeaveTypeDto>(leaveType);
    }
}