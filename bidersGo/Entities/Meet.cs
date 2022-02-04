using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bidersGo.Entities
{
    public class Meet:BaseEntity
    {
        public Student Student { get; set; }

        public Guid StudentId { get; set; }


        public Teacher Teacher { get; set; }
        public Guid TeacherId { get; set; }

    }
}
