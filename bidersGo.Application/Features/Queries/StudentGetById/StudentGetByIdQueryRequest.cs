using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace bidersGo.Application.Features.Queries.StudentGetById
{
    public class StudentGetByIdQueryRequest : IRequest<StudentByIdQueryResponse>
    {
        public Guid Guid { get; set; }
    }
}
