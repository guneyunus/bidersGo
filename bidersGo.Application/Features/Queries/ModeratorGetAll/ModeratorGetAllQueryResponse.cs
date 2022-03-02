using bidersGo.Application.Features.Queries.ModeratorGetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.ModeratorGetAll
{
    public class ModeratorGetAllQueryResponse
    {
        public List<ModeratorGetByIdQueryResponse> GetModeratorAll { get; set; }= new List<ModeratorGetByIdQueryResponse>();

    }
}
