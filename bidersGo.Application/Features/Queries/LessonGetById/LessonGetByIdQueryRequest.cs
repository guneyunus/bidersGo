using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.LessonGetById
{
    public class LessonGetByIdQueryRequest : IRequest<LessonGetByIdQueryResponse>
    {
        public Guid Guid { get; set; }
    }
}
