using Flowent.Sample.MediatR.LeaveManagement.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowent.Sample.MediatR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public ILeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            this._leaveRequestRepository = leaveRequestRepository;

            RuleFor(x => x.StartDate)
                .LessThan(p => p.StartDate).WithMessage("{PropertyName} must be bofore {ComparisonValue}");
            RuleFor(x => x.EndDate)
                .GreaterThan(p => p.StartDate).WithMessage("{Propertyname} must be after {ComparisonValue}");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    bool leaveTypeExists = await _leaveRequestRepository.Exists(id);
                    return !leaveTypeExists;
                })
                .WithMessage("{Propertyname} does not exists.");

        }
    }
}
