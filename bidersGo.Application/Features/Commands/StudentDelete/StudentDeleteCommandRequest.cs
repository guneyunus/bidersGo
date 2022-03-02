using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.StudentDelete
{

   public class StudentDeleteCommandRequest:IRequest<StudentDeleteCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
