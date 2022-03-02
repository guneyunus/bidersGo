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
        //workingHoursOfWeek yani yeni adıyla çalışma saatleri tablosunun id'si
            
        public Guid Id { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

    }

}
