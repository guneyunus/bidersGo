using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.AdminDelete
{
    public class AdminDeleteCommandRequest:IRequest<AdminDeleteCommandResponse>
    {
        public Guid Id { get; set; }

    }
}
