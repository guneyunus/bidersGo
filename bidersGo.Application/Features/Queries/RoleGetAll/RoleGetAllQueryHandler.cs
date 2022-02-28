using AutoMapper;
using bidersGo.Application.Features.Queries.RoleGetById;
using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.RoleGetAll
{
    public class RoleGetAllQueryHandler : IRequestHandler<RoleGetAllQueryRequest, RoleGetAllQueryResponse>
    {
        private readonly IUnitOfWork _unitOrWork;
        private readonly IMapper _mapper;
        public RoleGetAllQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOrWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<RoleGetAllQueryResponse> Handle(RoleGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            var role = _unitOrWork.RoleRepository.GetsAllRole();
            var model = new RoleGetAllQueryResponse();
            foreach (var item in role)
            {
                model.GetAllRole.Add(_mapper.Map<RoleGetByIdQueryResponse>(item));
            }

            return Task.FromResult(model);
        }
    }
}
