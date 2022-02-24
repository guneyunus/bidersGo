using bidersGo.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Domain.Entities
{
    public class WorkingForOneHour :BaseEntity
    {
        
        public WorkingHoursOfWeek week { get; set; }
        public Guid weekID { get; set; }
        public double? WorkingHourTotalTime { get; set; }
        public DateTime WorkingStart { get; set; }
        public DateTime WorkingStop { get; set; }
    }
}
