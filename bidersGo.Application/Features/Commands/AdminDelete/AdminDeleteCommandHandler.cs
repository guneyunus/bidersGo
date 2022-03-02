using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.AdminDelete
{
    public class AdminDeleteCommandHandler : IRequestHandler<AdminDeleteCommandRequest, AdminDeleteCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminDeleteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<AdminDeleteCommandResponse> Handle(AdminDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            var admin = _unitOfWork.AdminRepository.GetById(request.Id);

            _unitOfWork.AdminRepository.Delete(admin);
            _unitOfWork.Save();

            var model = new AdminDeleteCommandResponse();

            if (_unitOfWork.AdminRepository.GetById(request.Id) == null)
            {
                model.Succeed = true;
            }

            if (model.Succeed == true)
            {
                model.Message = "Admin kaydı başarıyla silindi";
            }
            else
            {
                model.Message = "Admin kaydı silme başarısız";
            }
            return Task<AdminDeleteCommandResponse>.FromResult(model);

        }
    }
}
