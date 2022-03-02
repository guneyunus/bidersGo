using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.ModeratorUpdate
{
    class ModeratorUpdateCommandHandler : IRequestHandler<ModeratorUpdateCommandRequest, ModeratorUpdateCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ModeratorUpdateCommandHandler(IUnitOfWork unitOfwork)
        {
            _unitOfWork = unitOfwork;
        }
        public async Task<ModeratorUpdateCommandResponse> Handle(ModeratorUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var moderator = _unitOfWork.ModeratorRepository.GetById(request.Id);

            var result = _unitOfWork.ModeratorRepository.AsyncUpdate(moderator);
            _unitOfWork.Save();

            return new ModeratorUpdateCommandResponse() 
            {
                Succeed=result==null?false:true,
                Message=result==null ?"Moderatör güncelleme işleminde hata gerçekleşti":"Moderatör güncelleme işlemi başarıyla gerçekleşti"
            };

        }
    }
}
