using AutoMapper;
using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.AddressGetById
{
   public class AddressGetByIdQueryHandler:IRequestHandler<AddressGetByIdQueryRequest,AddressGetByIdQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddressGetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<AddressGetByIdQueryResponse> Handle(AddressGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var adress = _unitOfWork.AddressRepository.GetById(request.Guid);

            AddressGetByIdQueryResponse model=_mapper.Map<AddressGetByIdQueryResponse>(adress);
            return Task<AddressGetByIdQueryResponse>.FromResult(model);
        }
    }
}
