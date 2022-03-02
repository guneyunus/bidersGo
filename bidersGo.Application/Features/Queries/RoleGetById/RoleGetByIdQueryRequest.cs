using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.RoleGetById
{
    public class RoleGetByIdQueryRequest: IRequest<RoleGetByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}
