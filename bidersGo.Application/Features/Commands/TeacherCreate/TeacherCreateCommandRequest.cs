﻿using bidersGo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.TeacherCreate
{
  public  class TeacherCreateCommandRequest:IRequest<TeacherCreateCommandResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Branch { get; set; }
        public int TcKimlik { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
        public List<WorkingHoursOfWeek> WorkingHoursOfWeek { get; set; }
        public bool IsWorking { get; set; }
        public Lesson Lesson { get; set; }

        public Guid LessonId { get; set; }




        public List<Meet> Meets { get; set; }

    }
}