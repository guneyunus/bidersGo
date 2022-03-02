using AutoMapper;
using bidersGo.Application.Features.Queries.AdminGetById;
using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.AdminGetAll
{
    public class AdminGetAllQueryHandler : IRequestHandler<AdminGetAllQueryRequest, AdminGetAllQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AdminGetAllQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<AdminGetAllQueryResponse> Handle(AdminGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            var admin = _unitOfWork.AdminRepository.GetAdminAll();
            var model = new AdminGetAllQueryResponse();

            foreach (var item in admin)
            {
                model.AdminGetAll.Add(_mapper.Map<AdminGetByIdQueryResponse>(item));
            }


            return Task.FromResult(model);
        }
    }
}
