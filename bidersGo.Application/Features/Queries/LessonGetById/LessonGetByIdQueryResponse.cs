using bidersGo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.LessonGetById
{
    public class LessonGetByIdQueryResponse
    {
        public Guid Id { get; set; }
        public string LessonName { get; set; }
        public bool IsOnline { get; set; }
        
    }
}
