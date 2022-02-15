using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using bidersGo.Application.Interfaces.Repositories;
using bidersGo.Domain.Entities;
using MediatR;

namespace bidersGo.Application.Features.Commands.AddressCreate
{
    public class AddressCreateCommandHandler : IRequestHandler<AddressCreateCommandRequest, AddressCreateCommandResponse>
    {
        private readonly IAddressRepository _addressRepository;
        public AddressCreateCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<AddressCreateCommandResponse> Handle(AddressCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var YeniAdres = new Address()
            {
                AddressType = request.AddressType,
                BuildName = request.BuildName,
                BuildNo = request.BuildNo,
                City = request.City,
                CreatedDate = DateTime.Now,
                State = request.State,
                ZipCode = request.ZipCode,
                Street = request.Street
            };

             var adres = _addressRepository.CreateAsync(YeniAdres);

             return new AddressCreateCommandResponse()
             {
                 Succeed = adres == null ? false : true,
                 Message = "Adres Başarıyla Eklendi"
             };
        }
    }
}
