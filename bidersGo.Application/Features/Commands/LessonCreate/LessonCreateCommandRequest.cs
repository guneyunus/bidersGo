using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.LessonCreate
{
    public class LessonCreateCommandRequest : IRequest<LessonCreateCommandResponse>
    {
        public string LessonName { get; set; }
        public bool IsOnline { get; set; }
    }
}
