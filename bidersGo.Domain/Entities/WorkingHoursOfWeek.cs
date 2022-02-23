using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using bidersGo.Domain.Common;

namespace bidersGo.Domain.Entities
{
    public class WorkingHoursOfWeek:BaseEntity
    { 
        public Teacher Teacher { get; set; }
        public Guid TeacherId{ get; set; }
        public List<WorkingForOneHour> WorkingForOneHours { get; set; } = new List<WorkingForOneHour>();

    }
}
