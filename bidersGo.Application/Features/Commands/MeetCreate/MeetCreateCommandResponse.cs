using bidersGo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.MeetCreate
{
    public class MeetCreateCommandResponse
    {
        public string TeacherName  { get; set; }
        public string StudentName  { get; set; }
        public DateTime LessonTime { get; set; }
        public DateTime? LessonFinishTime { get; set; }
        public Address Address { get; set; }
        public decimal Price { get; set; }
        public bool Succeed { get; set; }
        public string Message { get; set; }
    }
}
