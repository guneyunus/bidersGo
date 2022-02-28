using AutoMapper;
using bidersGo.Application.Interfaces.UnitOfWork;
using bidersGo.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.UserGetById
{
    public class UserGetByIdQueryHandler : IRequestHandler<UserGetByIdQueryRequest, UserGetByIdQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UserGetByIdQueryHandler(IMapper mapper,IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<UserGetByIdQueryResponse> Handle(UserGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            
            var user =  _unitOfWork.UserRepository.GetUserById(request.UserId);
            var model = _mapper.Map<UserGetByIdQueryResponse>(user);

           // return Task<UserGetByIdQueryResponse>.FromResult(model);
            return model;


        }
    }
}
