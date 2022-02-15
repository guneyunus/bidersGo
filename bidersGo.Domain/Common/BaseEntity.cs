using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bidersGo.Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }


    }
}
