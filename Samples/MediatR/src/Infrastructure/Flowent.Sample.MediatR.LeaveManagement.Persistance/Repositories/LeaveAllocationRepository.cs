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
    internal class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
            => await _dbContext.LeaveAllocations.Include(p => p.LeaveType).ToListAsync();

        public async Task<LeaveAllocation?> GetLeaveAllocationWithDetails(int id)
        => await _dbContext.LeaveAllocations.Include(p => p.LeaveType).FirstOrDefaultAsync(p => p.Id == id);
    }
}
