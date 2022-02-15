using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using bidersGo.Domain.Common;

namespace bidersGo.Domain.Entities
{
    public class Subscription:BaseEntity
    {
        public List<Student>Student { get; set; }
        public decimal Amount { get; set; }
        public decimal PaidAmunt { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
        public bool IsActive { get; set; }
        public List<SubscriptionType>SubscriptionTypes { get; set; }
    }
}
