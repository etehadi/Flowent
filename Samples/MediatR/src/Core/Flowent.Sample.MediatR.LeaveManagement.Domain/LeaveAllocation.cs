using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flowent.Sample.MediatR.LeaveManagement.Domain.Common;

namespace Flowent.Sample.MediatR.LeaveManagement.Domain;
public class LeaveAllocation : BaseDomainEntity
{   
    public int NumberOfDays { get; set; }   
    public LeaveType LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}