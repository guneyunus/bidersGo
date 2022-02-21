using bidersGo.Application.Features.Queries.TeacherGetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.TeacherGetByLesson
{
    public class TeacherGetByLessonQueryResponse
    {
        public List<TeacherGetByIdQueryResponse> TeacherGetByLesson { get; set; }
    }
}
