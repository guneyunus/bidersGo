using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;

namespace bidersGo.Application.Features.Queries.WorkingWeekForLesson
{
    public class WorkingWeekOfHourInOneQueryHandler : IRequestHandler<WorkingWeekOfHourInOneQueryRequest, WorkingWeekOfHourInOneQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public WorkingWeekOfHourInOneQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<WorkingWeekOfHourInOneQueryResponse> Handle(WorkingWeekOfHourInOneQueryRequest request, CancellationToken cancellationToken)
        {
            //buradaki guid öğretmenin çalışma tablosunu temsil eden guid
            var tablo = _unitOfWork.workingWeekRepository.WorkingHoursOfWeek(request.Id);

            var response = new WorkingWeekOfHourInOneQueryResponse()
            {
                WorkingHoursOfWeek = tablo
            };

            return Task.FromResult(response);
        }
    }
}
