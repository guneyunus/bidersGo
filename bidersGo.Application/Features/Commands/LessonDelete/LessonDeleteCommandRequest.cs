using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.LessonDelete
{
    
    public class LessonDeleteCommandRequest:IRequest<LessonDeleteCommandResponse>
    {
        public Guid Id { get; set; }
        public string LessonName { get; set; }
        


    }
}
