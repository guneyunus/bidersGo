using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.ModeratorCreate
{
     public   class ModeratorCreateCommandRequest:IRequest<ModeratorCreateCommandResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string TcKimlik { get; set; }
    }
}
