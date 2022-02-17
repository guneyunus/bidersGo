using bidersGo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.TeacherGetById
{
    public class TeacherGetByIdQueryResponse
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Branch { get; set; }
        public int TcKimlik { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public Lesson Lesson { get; set; }
        public Guid LessonId { get; set; }
        public List<WorkingHoursOfWeek> WorkingHoursOfWeek { get; set; }
    }
}
