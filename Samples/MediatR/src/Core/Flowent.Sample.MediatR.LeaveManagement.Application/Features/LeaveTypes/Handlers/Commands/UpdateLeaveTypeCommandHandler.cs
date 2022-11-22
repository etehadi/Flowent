using AutoMapper;
using Flowent.Sample.MediatR.LeaveManagement.Application.DTOs.LeaveType.Validators;
using Flowent.Sample.MediatR.LeaveManagement.Application.Exceptions;
using Flowent.Sample.MediatR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using Flowent.Sample.MediatR.LeaveManagement.Application.Persistence.Contracts;
using Flowent.Sample.MediatR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowent.Sample.MediatR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepositiry _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepositiry leaveTypeRepository, IMapper mapper)
        {
            this._leaveTypeRepository = leaveTypeRepository;
            this._mapper = mapper;
        }


        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeValidator();
            var validationResult = validator.Validate(request.LeaveTypeDto);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var leaveType = await _leaveTypeRepository.Get(request.LeaveTypeDto.Id);
            _mapper.Map(request.LeaveTypeDto, leaveType);
            await _leaveTypeRepository.Update(leaveType);

            return Unit.Value;
        }
    }
}
