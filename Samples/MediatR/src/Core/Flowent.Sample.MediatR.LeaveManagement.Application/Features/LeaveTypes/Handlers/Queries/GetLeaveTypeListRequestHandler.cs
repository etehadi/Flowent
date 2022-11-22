using AutoMapper;
using Flowent.Sample.MediatR.LeaveManagement.Application.DTOs.LeaveType;
using Flowent.Sample.MediatR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using Flowent.Sample.MediatR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowent.Sample.MediatR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeListRequestHandler : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDto>>
    {
        private readonly ILeaveAllocationRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeListRequestHandler(ILeaveAllocationRepository leaveTypeRepository, IMapper mapper)
        {
            this._leaveTypeRepository = leaveTypeRepository;
            this._mapper = mapper;
        }

        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
        {
            var result = await _leaveTypeRepository.GetAll();
            return _mapper.Map<List<LeaveTypeDto>>(result);
        }
    }
}
