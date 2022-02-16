using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Domain.Common;

namespace bidersGo.Domain.Entities
{
    public class LessonDetail:BaseEntity
    {
        public Lesson Lesson { get; set; }
        public Guid LessonId { get; set; }
        public int  SoruSayisi { get; set; }

    }
}
