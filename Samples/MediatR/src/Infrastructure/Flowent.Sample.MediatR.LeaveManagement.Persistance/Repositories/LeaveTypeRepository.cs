using Flowent.Sample.MediatR.LeaveManagement.Application.Contracts.Persistence;
using Flowent.Sample.MediatR.LeaveManagement.Domain;

namespace Flowent.Sample.MediatR.LeaveManagement.Persistance.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepositiry
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
