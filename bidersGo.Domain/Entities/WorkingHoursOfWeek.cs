using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace bidersGo.Domain.Entities
{
    public class WorkingHoursOfWeek
    { 
        public Teacher Teacher { get; set; }
        public Guid TeacherId{ get; set; }
        public int Id { get; set; }
        public DateTime WorkingHours { get; set; }
        public DateTime WorkingStart { get; set; }
        public DateTime WorkingStop { get; set; }
    }
}
