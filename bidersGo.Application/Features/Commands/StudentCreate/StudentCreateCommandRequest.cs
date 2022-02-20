using bidersGo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.StudentCreate
{
   public class StudentCreateCommandRequest:IRequest<StudentCreateCommandResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int TcKimlik { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsSearchLesson { get; set; }
        public Guid SubscriptionId { get; set; }
        public Guid AddressId { get; set; }
    }
}
