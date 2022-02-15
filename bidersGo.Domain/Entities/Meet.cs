using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Domain.Common;

namespace bidersGo.Domain.Entities
{
    public class Meet:BaseEntity
    {
        public Student Student { get; set; }
        public Guid StudentId { get; set; }
        public Teacher Teacher { get; set; }
        public Guid TeacherId { get; set; }
        public DateTime LessonTime { get; set; }
        public DateTime? LessonFinishTime { get; set; }
        public Address Address { get; set; }
        public decimal Price { get; set; }
        public bool IsApproved { get; set; } = false;

    }
}
