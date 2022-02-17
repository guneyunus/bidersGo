using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace bidersGo.Application.Features.Queries.TeacherOfLesson
{
    public class TeacherOfLessonQueryRequest : IRequest<TeacherOfLessonQueryResponse>
    {
        public Guid Guid { get; set; }
    }
}
