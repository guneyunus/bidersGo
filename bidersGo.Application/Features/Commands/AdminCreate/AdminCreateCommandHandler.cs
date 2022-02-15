using bidersGo.Application.Interfaces.UnitOfWork;
using bidersGo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.AdminCreate
{
    public class AdminCreateCommandHandler : IRequestHandler<AdminCreateCommandRequest, AdminCreateCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminCreateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AdminCreateCommandResponse> Handle(AdminCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var NewAdmin = new Admin() 
            {
                Name=request.Name,
                Surname=request.Surname,
                Email=request.Email,
                NickName=request.NickName,
                Password=request.Password
            };
            var admin = _unitOfWork.AdminRepository.CreateAsync(NewAdmin);
            return new AdminCreateCommandResponse() 
            {
                Succeed=admin==null?false:true,
                Message="Kayıt işlemi başarıyla gerçekleşmiştir"
            };
        }
    }
}
