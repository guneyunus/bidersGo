using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bidersGo.Entities
{
    public class Lesson : BaseEntity
    {
        

        [Required, StringLength(40)]

        public string LessonName { get; set; }

        public bool IsOnline { get; set; }
     
        public int Amount { get; set; }

        public decimal Price { get; set; }

    }
}
