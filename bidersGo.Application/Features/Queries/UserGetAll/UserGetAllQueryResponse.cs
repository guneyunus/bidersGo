using bidersGo.Application.Features.Queries.UserGetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.UserGetAll
{
    public class UserGetAllQueryResponse
    {
        public List<UserGetByIdQueryResponse> UserGetAll { get; set; } = new List<UserGetByIdQueryResponse>();
    }
}
