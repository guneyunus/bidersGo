using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidersGo.Application.Features.Queries.TeacherGetById;
using bidersGo.Domain.Entities;

namespace bidersGo.Application.Features.Queries.TeacherOfLesson
{
    public class TeacherOfLessonQueryResponse
    {
        public List<TeacherGetByIdQueryResponse> Teachers { get; set; } = new List<TeacherGetByIdQueryResponse>();
    }
}
