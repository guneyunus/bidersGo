using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.LessonUpdate
{
    public class LessonUpdateCommandHandler : IRequestHandler<LessonUpdateCommandRequest, LessonUpdateCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public LessonUpdateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<LessonUpdateCommandResponse> Handle(LessonUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var lesson =  _unitOfWork.LessonRepository.GetById(request.Guid);
            lesson.IsOnline = request.IsOnline;
            lesson.LessonName = request.LessonName;
            var result =  _unitOfWork.LessonRepository.AsyncUpdate(lesson);
            _unitOfWork.Save();

            return new LessonUpdateCommandResponse()
            {
                Succeed = result == null ? false : true,
                Message = result == null ? "Ders Güncelleme işleminde hata gerçekleşti" : "Ders Güncelleme işlemi başarıyla gerçekleşti"
            };
        }
    }
}
