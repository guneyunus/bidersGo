using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.TeacherGetByLesson
{
    public class TeacherGetByLessonQueryResponse
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Branch { get; set; }
        public int TcKimlik { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
    }
}
