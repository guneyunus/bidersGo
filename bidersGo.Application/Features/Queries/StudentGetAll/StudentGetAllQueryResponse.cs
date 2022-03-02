using bidersGo.Application.Features.Queries.StudentGetById;
using bidersGo.Application.Features.Queries.TeacherGetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.StudentGetAll
{
  public class StudentGetAllQueryResponse
    {
        public List<StudentByIdQueryResponse> StudentGetAll { get; set; } = new List<StudentByIdQueryResponse>();

    }
}
