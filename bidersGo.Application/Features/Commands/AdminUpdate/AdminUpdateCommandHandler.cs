using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.AdminUpdate
{
    public class AdminUpdateCommandHandler : IRequestHandler<AdminUpdateCommandRequest, AdminUpdateCommandResponse>
    {

        private readonly IUnitOfWork _unitOfWork;
        public AdminUpdateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<AdminUpdateCommandResponse> Handle(AdminUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var admin = _unitOfWork.AdminRepository.GetById(request.Id);
            var result = _unitOfWork.AdminRepository.AsyncUpdate(admin);
            _unitOfWork.Save();

            return new AdminUpdateCommandResponse()
            {
                Succeed = result == null ? false : true,
                Message = result == null ? "Admin Güncelleme işleminde hata gerçekleşti" : "Admin Güncelleme işlemi başarıyla gerçekleşti"
            };

        }
    }
}
