using bidersGo.Application.Features.Queries.RoleGetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.RoleGetAll
{
    public class RoleGetAllQueryResponse
    {
        public List<RoleGetByIdQueryResponse> GetAllRole { get; set; } = new List<RoleGetByIdQueryResponse>();
    }
}
