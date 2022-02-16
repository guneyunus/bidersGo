using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using bidersGo.Application.Interfaces.Repositories;
using bidersGo.Application.Interfaces.UnitOfWork;
using bidersGo.Domain.Entities;
using MediatR;

namespace bidersGo.Application.Features.Commands.AddressCreate
{
    public class AddressCreateCommandHandler : IRequestHandler<AddressCreateCommandRequest, AddressCreateCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddressCreateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

             var adres = _unitOfWork.AddressRepository.CreateAsync(YeniAdres);
             _unitOfWork.Save();

             return new AddressCreateCommandResponse()
             {
                 Succeed = adres == null ? false : true,
                 Message = adres == null ? "Adres Kaydedilemedi" : "Adres Başarıyla Eklendi"
             };
        }
    }
}
