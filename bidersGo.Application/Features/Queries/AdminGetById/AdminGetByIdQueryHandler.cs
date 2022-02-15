using AutoMapper;
using bidersGo.Application.Interfaces.UnitOfWork;
using bidersGo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.AdminGetById
{
    public class AdminGetByIdQueryHandler:IRequestHandler<AdminGetByIdQueryRequest,AdminGetByIdQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminGetByIdQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<AdminGetByIdQueryResponse> Handle(AdminGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var admin = _unitOfWork.AdminRepository.GetAdminById(request.Guid);
            AdminGetByIdQueryResponse model = _mapper.Map<AdminGetByIdQueryResponse>(admin);
            return Task<AdminGetByIdQueryResponse>.FromResult(model);
        }
    }
}
