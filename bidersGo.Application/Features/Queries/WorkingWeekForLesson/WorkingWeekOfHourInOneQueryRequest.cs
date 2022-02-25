using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace bidersGo.Application.Features.Queries.WorkingWeekForLesson
{
    public class WorkingWeekOfHourInOneQueryRequest : IRequest<WorkingWeekOfHourInOneQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
