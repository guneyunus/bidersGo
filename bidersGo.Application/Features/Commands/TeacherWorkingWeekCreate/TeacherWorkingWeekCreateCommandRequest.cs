using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidersGo.Domain.Entities;
using MediatR;

namespace bidersGo.Application.Features.Commands.TeacherWorkingWeekCreate
{
    public class TeacherWorkingWeekCreateCommandRequest : IRequest<TeacherWorkingWeekCreateCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
