using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace bidersGo.Application.Features.Commands.RolesAdded
{
    public class RolesAddCommandRequest:IRequest<RolesAddCommandResponse>
    {
        public string RoleName { get; set; }
    }
}
