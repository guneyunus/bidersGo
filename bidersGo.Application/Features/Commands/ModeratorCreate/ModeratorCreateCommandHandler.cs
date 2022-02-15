using bidersGo.Application.Interfaces.UnitOfWork;
using bidersGo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.ModeratorCreate
{
  public  class ModeratorCreateCommandHandler:IRequestHandler<ModeratorCreateCommandRequest,ModeratorCreateCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModeratorCreateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ModeratorCreateCommandResponse> Handle(ModeratorCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var NewModerator = new Moderator() 
            {
                Name=request.Name,
                Surname=request.Surname,
                Email=request.Email,
                TcKimlik=request.TcKimlik,
                NickName=request.NickName,
                Password=request.Password
            };
            var moderator = _unitOfWork.ModeratorRepository.CreateAsync(NewModerator);

            return new ModeratorCreateCommandResponse()
            {
                Succeed = moderator == null ? false : true,
                Message="Kayıt işlemi başarıyla gerçekleşmişitir"
            };
        }
    }
}
