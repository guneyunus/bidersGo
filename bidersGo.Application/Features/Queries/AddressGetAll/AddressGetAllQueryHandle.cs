using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using bidersGo.Application.Features.Queries.AddressGetById;
using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;

namespace bidersGo.Application.Features.Queries.AddressGetAll
{
    public class AddressGetAllQueryHandle : IRequestHandler<AddressGetAllQueryRequest, AddressGetAllQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddressGetAllQueryHandle(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<AddressGetAllQueryResponse> Handle(AddressGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            var data = _unitOfWork.AddressRepository.getAllAdresAddresses()
                .Select(x => _mapper.Map<AddressGetByIdQueryResponse>(x))
                .ToList();
            var model = new AddressGetAllQueryResponse()
            {
                AddressGetAll = data
            };

            return Task<AddressGetAllQueryResponse>.FromResult(model);
        }
    }
}
