using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.ModeratorDelete
{
    public class ModeratorDeleteCommandRequest:IRequest<ModeratorDeleteCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
