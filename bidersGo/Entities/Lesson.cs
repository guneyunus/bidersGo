using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bidersGo.Entities
{
    public class Lesson : BaseEntity
    {
        public string LessonName { get; set; }
        public bool IsOnline { get; set; }
        public List<LessonDetail> LessonDetails { get; set; }

        public List<Meet> Meets { get; set; }
        

    }
}
