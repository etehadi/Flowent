﻿using Flowent.Sample.MediatR.LeaveManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowent.Sample.MediatR.LeaveManagement.Application.DTOs.LeaveType;
public class LeaveTypeDto : BaseDto, ILeaveTypeDto
{
    public string Name { get; set; }
    public int DefaultDays { get; set; }
}
