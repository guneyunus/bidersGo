using AutoMapper;
using bidersGo.Application.Features.Queries.UserGetById;
using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.UserGetAll
{
    public class UserGetAllQueryHandler : IRequestHandler<UserGetAllQueryRequest, UserGetAllQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserGetAllQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<UserGetAllQueryResponse> Handle(UserGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            var user = _unitOfWork.UserRepository.GetUsersAll();
            var model = new UserGetAllQueryResponse();
            foreach (var item in user)
            {
                model.UserGetAll.Add(_mapper.Map<UserGetByIdQueryResponse>(item));
            }


            return Task.FromResult(model);
        }
    }
}
