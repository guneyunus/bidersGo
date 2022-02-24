using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidersGo.Domain.Entities;
using MediatR;

namespace bidersGo.Application.Features.Commands.TeacherWorkingHoursCreate
{
    public class TeacherWorkingHoursCreateCommandRequest : IRequest<TeacherWorkingHoursCreateCommandResponse>
    {
        public WorkingHoursOfWeek week { get; set; }
        public Guid weekID { get; set; }
        public DateTime WorkingStart { get; set; }
        public DateTime WorkingStop { get; set; }

    }

}
