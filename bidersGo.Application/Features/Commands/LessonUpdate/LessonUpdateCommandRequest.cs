using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.LessonUpdate
{
    public class LessonUpdateCommandRequest : IRequest<LessonUpdateCommandResponse>
    {
        public Guid Guid { get; set; }
        public string LessonName { get; set; }
        public bool IsOnline { get; set; }
    }
}
