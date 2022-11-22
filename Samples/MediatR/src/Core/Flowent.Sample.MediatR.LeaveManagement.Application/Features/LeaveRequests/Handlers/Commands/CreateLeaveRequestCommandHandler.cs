using AutoMapper;
using Flowent.Sample.MediatR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using Flowent.Sample.MediatR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using Flowent.Sample.MediatR.LeaveManagement.Application.Persistence.Contracts;
using Flowent.Sample.MediatR.LeaveManagement.Application.Responses;
using Flowent.Sample.MediatR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowent.Sample.MediatR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }


        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {

            var validationResult = await new CreateLeaveRequestDtoValidator(_leaveRequestRepository)
                                        .ValidateAsync(request.LeaveRequestDto, cancellationToken);

            if (!validationResult.IsValid)
                return new BaseCommandResponse
                {
                    Success = false,
                    Message = "Createion Failed",
                    Errors = validationResult.Errors.Select(p => p.ErrorMessage).ToList()
                };


            var leaveRequest = await _leaveRequestRepository.Add(_mapper.Map<LeaveRequest>(request.LeaveRequestDto));

            return new BaseCommandResponse
            {
                Success = true,
                Message = "Createion Successful",
                Id = leaveRequest.Id
            };
        }
    }
}
