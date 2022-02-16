using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using bidersGo.Application.Interfaces.UnitOfWork;
using bidersGo.Domain.Entities;
using MediatR;

namespace bidersGo.Application.Features.Queries.GetAddressById
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQueryRequest, GetAddressByIdQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public GetAddressByIdQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<GetAddressByIdQueryResponse> Handle(GetAddressByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var adres = _unitOfWork.AddressRepository.GetAddressById(request.Guid);

            return 

        }
    }
}
