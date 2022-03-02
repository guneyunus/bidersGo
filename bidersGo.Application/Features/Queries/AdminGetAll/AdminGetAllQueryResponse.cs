using bidersGo.Application.Features.Queries.AdminGetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.AdminGetAll
{
    public class AdminGetAllQueryResponse
    {
        public List<AdminGetByIdQueryResponse> AdminGetAll { get; set; } = new List<AdminGetByIdQueryResponse>();
    }
}
