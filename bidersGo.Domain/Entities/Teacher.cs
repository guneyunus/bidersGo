using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using bidersGo.Domain.Common;

namespace bidersGo.Domain.Entities
{
    public class Teacher:BaseEntity
    { 
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Branch { get; set; }
        public string TcKimlik { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
        public List<WorkingHoursOfWeek> WorkingHoursOfWeek { get; set; }
        public bool IsWorking { get; set; }
        public Lesson Lesson { get; set; }
        public Guid LessonId { get; set; }
        public List<Meet> Meets { get; set; }


    }
}
