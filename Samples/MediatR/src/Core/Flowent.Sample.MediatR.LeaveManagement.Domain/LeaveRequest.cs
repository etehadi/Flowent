using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flowent.Sample.MediatR.LeaveManagement.Domain.Common;

namespace Flowent.Sample.MediatR.LeaveManagement.Domain;
public class LeaveRequest: BaseDomainEntity
{ 
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public LeaveType LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public DateTime DateRequested { get; set; }
    public string RequestComments { get; set; }
    public DateTime? DateActioned { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }
}
