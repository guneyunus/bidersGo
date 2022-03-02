using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.LessonDelete
{
    public class LessonDeleteCommandHandler : IRequestHandler<LessonDeleteCommandRequest, LessonDeleteCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public LessonDeleteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<LessonDeleteCommandResponse> Handle(LessonDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            var lesson = _unitOfWork.LessonRepository.GetById(request.Id);
            _unitOfWork.LessonRepository.Delete(lesson);
            _unitOfWork.Save();

            var model = new LessonDeleteCommandResponse();
            if (_unitOfWork.LessonRepository.GetById(request.Id) == null)
            {
                model.Succeed = true;
            }
            if (model.Succeed == true)
            {
                model.Message = "Ders kaydı başarıyla silindi";
            }
            else
            {
                model.Message = "Ders kaydı silme başarısız";
            }
            return Task<LessonDeleteCommandResponse>.FromResult(model);
        }
    }
}
