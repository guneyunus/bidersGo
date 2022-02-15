using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidersGo.Domain.Entities;

namespace bidersGo.Application.Features.Queries.StudentGetById
{
    public class StudentByIdQueryResponse
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int TcKimlik { get; set; }
        public Address Address { get; set; }
        public List<Meet> Meets { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
    }
}
