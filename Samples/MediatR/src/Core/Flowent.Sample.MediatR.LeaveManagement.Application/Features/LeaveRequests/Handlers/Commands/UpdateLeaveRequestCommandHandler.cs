using AutoMapper;
using Flowent.Sample.MediatR.LeaveManagement.Application.DTOs.LeaveRequest;
using Flowent.Sample.MediatR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using Flowent.Sample.MediatR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowent.Sample.MediatR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            this._leaveRequestRepository = leaveRequestRepository;
            this._mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
           var leaveRequest  =await _leaveRequestRepository.Get(request.Id);

            if (request.LeaveRequestDto != null)
            {
                _mapper.Map(request.LeaveRequestDto, leaveRequest);
                await _leaveRequestRepository.Update(leaveRequest);
            }
            else if (request.ChangeLeaveRequestApprovalDto != null)
            {
                await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovalDto.Approval);
            }

            return Unit.Value;
        }
    }
}
