using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.ModeratorDelete
{
    public class ModeratorDeleteCommandHandler : IRequestHandler<ModeratorDeleteCommandRequest, ModeratorDeleteCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ModeratorDeleteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<ModeratorDeleteCommandResponse> Handle(ModeratorDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            var moderator = _unitOfWork.ModeratorRepository.GetById(request.Id);
            _unitOfWork.ModeratorRepository.Delete(moderator);
            _unitOfWork.Save();
            var model = new ModeratorDeleteCommandResponse();

            if (_unitOfWork.ModeratorRepository.GetById(request.Id) == null)
            {
                model.Succeed = true;
            }

            if (model.Succeed == true)
            {
                model.Message = "Moderator kaydı başarıyla silindi";
            }
            else
            {
                model.Message = "Moderator kaydı silme başarısız";
            }
            return Task<ModeratorDeleteCommandResponse>.FromResult(model);

        }
    }
}
