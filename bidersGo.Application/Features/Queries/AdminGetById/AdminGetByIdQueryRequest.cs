using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.AdminGetById
{
    public class AdminGetByIdQueryRequest: IRequest<AdminGetByIdQueryResponse>
    {
        public Guid Guid { get; set; }
    }
}
