using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.UserGetById
{
    public class UserGetByIdQueryRequest : IRequest<UserGetByIdQueryResponse>
    {
        public string UserId { get; set; }
    }
}
