using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Domain.Entities
{
    public class WorkingForOneHour
    {
        public double WorkingHourTotalTime { get; set; }
        public DateTime WorkingStart { get; set; }
        public DateTime WorkingStop { get; set; }
    }
}
