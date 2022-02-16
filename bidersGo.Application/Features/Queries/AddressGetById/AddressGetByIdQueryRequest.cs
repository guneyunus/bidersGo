using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.AddressGetById
{
    public class AddressGetByIdQueryRequest:IRequest<AddressGetByIdQueryResponse>
    {
        public Guid Guid { get; set; }
    }
}
