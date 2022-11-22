using Flowent.Sample.MediatR.LeaveManagement.Application.DTOs.LeaveType;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowent.Sample.MediatR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class UpdateLeaveTypeValidator : AbstractValidator<LeaveTypeDto>
    {
        public UpdateLeaveTypeValidator()
        {
            Include(new ILeaveTypeDtoValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present.");
        }
    }
}
