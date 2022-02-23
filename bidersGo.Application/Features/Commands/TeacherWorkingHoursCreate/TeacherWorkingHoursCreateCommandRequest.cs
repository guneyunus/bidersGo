using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace bidersGo.Application.Features.Commands.TeacherWorkingHoursCreate
{
    public class TeacherWorkingHoursCreateCommandRequest : IRequest<TeacherWorkingHoursCreateCommandResponse>
    {
        public DateTime WorkingStart { get; set; }
        public DateTime WorkingStop { get; set; }

    }

}
