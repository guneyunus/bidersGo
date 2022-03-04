using bidersGo.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace bidersGo.Domain.Entities
{
    public class WorkingForOneHour :BaseEntity
    {
        
        public WorkingHoursOfWeek week { get; set; }
        public Guid weekID { get; set; }
        
        [JsonProperty(PropertyName = "Text")]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "StartDate")]
        public string StartDate { get; set; }
        [JsonProperty(PropertyName = "EndDate")]
        public string EndDate { get; set; }

        [JsonProperty(PropertyName = "AllDay")]
        public bool AllDay { get; set; } = false;
        [JsonProperty(PropertyName = "RecurrenceRule")]
        public string RecurrenceRule { get; set; }
        [JsonProperty(PropertyName = "RecurrenceException")]
        public string RecurrenceException { get; set; }
        [JsonProperty(PropertyName = "IsDisabled")]
        public bool isDisabled { get; set; }

    }
}
