using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidersGo.Domain.Entities;
using MediatR;

namespace bidersGo.Application.Features.Commands.MeetCreate
{
   public  class MeetCreateCommandRequest : IRequest<MeetCreateCommandResponse>
    {
        public Guid StudentGuid { get; set; }
        public Guid TeacherGuid { get; set; }

        public DateTime LessonTime { get; set; }
        public DateTime LessonFinishTime { get; set; }
        public Address Address { get; set; }

    }
}
