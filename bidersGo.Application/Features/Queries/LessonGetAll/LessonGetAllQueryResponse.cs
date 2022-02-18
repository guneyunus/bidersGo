using bidersGo.Application.Features.Queries.LessonGetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.LessonGetAll
{
    public class LessonGetAllQueryResponse
    {
        public List<LessonGetByIdQueryResponse> LessonGetAll { get; set; }= new List<LessonGetByIdQueryResponse>();
    }
}
