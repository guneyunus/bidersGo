using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bidersGo.Entities
{
    public class LessonDetail
    {
        public Lesson Lesson { get; set; }
        public Guid LessonId { get; set; }
        public int  SoruSayisi { get; set; }

    }
}
