using Flowent.Sample.MediatR.LeaveManagement.Application.Contracts.Persistence;
using Flowent.Sample.MediatR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowent.Sample.MediatR.LeaveManagement.Persistance.Repositories
{
    internal class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveRequestRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus)
        {
            leaveRequest.Approved = ApprovalStatus;
            _dbContext.Entry(leaveRequest).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
            => await _dbContext.LeaveRequests.Include(r => r.LeaveType).ToListAsync();

        public async Task<LeaveRequest?> GetLeaveRequestWithDetails(int id)
            => await _dbContext.LeaveRequests.Include(r => r.LeaveType).FirstOrDefaultAsync(r => r.Id == id);
    }
}
