using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.TeacherGetById
{
    public class TeacherGetByIdQueryRequest : IRequest<TeacherGetByIdQueryResponse>
    {
        public Guid Guid { get; set; }
    }
}
