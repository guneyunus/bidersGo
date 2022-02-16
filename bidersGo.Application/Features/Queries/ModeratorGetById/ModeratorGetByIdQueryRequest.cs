using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.ModeratorGetById
{
    public class ModeratorGetByIdQueryRequest:IRequest<ModeratorGetByIdQueryResponse>
    {
        public Guid Guid { get; set; }
    }
}
