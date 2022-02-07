using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace bidersGo.Entities
{
    public class SubscriptionType:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Month { get; set; }
        public decimal Price { get; set; }


    }
}
