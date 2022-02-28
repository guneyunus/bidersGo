using AutoMapper;
using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.RoleGetById
{
    public class RoleGetByIdQueryHandler : IRequestHandler<RoleGetByIdQueryRequest, RoleGetByIdQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoleGetByIdQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<RoleGetByIdQueryResponse> Handle(RoleGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var role= _unitOfWork.RoleRepository.GetRoleById(request.Id);
            var model = _mapper.Map<RoleGetByIdQueryResponse>(role);

             return Task<RoleGetByIdQueryResponse>.FromResult(model);
            //return model;
        }
    }
}
