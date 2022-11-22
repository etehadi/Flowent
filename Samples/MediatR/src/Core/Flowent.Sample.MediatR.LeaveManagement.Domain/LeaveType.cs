using Flowent.Sample.MediatR.LeaveManagement.Domain.Common;

namespace Flowent.Sample.MediatR.LeaveManagement.Domain;
public class LeaveType : BaseDomainEntity
{
    public string Name { get; set; }
    public int DefaultDays { get; set; }
}
