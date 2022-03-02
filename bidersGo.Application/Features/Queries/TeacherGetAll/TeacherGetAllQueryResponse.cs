using bidersGo.Application.Features.Queries.TeacherGetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.TeacherGetAll
{
    public class TeacherGetAllQueryResponse
    {
        public List<TeacherGetByIdQueryResponse> TeacherGetAll { get; set; } = new List<TeacherGetByIdQueryResponse>();

    }
}