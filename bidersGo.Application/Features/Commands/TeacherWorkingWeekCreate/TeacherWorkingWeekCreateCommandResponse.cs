using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidersGo.Domain.Entities;

namespace bidersGo.Application.Features.Commands.TeacherWorkingWeekCreate
{
    public class TeacherWorkingWeekCreateCommandResponse
    {
        public bool Succeed { get; set; }
        public string Message { get; set; }
        public WorkingHoursOfWeek Data { get; set; }

    }
}
