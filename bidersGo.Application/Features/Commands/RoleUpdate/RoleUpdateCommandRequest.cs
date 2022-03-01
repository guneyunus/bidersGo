using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.RoleUpdate
{
    public class RoleUpdateCommandRequest :IRequest<RoleUpdateCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
