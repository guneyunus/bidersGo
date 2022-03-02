using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.TeacherDelete
{
    public class TeacherDeleteCommandRequest : IRequest<TeacherDeleteCommandResponse>
    {
        public Guid Id { get; set; }
      
     
    }
}