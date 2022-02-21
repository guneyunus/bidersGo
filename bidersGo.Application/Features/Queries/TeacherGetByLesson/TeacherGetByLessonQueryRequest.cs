using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.TeacherGetByLesson
{
    public class TeacherGetByLessonQueryRequest : IRequest<TeacherGetByLessonQueryResponse>
    {
        public Guid LessonId { get; set; }
    }
}
