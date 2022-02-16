using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidersGo.Domain.Entities;
using MediatR;

namespace bidersGo.Application.Features.Queries.GetAddressById
{
    public class GetAddressByIdQueryRequest : IRequest<GetAddressByIdQueryResponse>
    {
        public Guid Guid { get; set; }
    }
}
