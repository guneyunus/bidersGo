using bidersGo.Application.Interfaces.UnitOfWork;
using bidersGo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.LessonCreate
{
    public class LessonCreateCommandHandler : IRequestHandler<LessonCreateCommandRequest, LessonCreateCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public LessonCreateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<LessonCreateCommandResponse> Handle(LessonCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var newLesson = new Lesson()
            {
                LessonName = request.LessonName,
                IsOnline = request.IsOnline
            };
            var lesson =  _unitOfWork.LessonRepository.CreateAsync(newLesson);
            _unitOfWork.Save();

            return new LessonCreateCommandResponse()
            {
                Succeed = lesson == null ? false : true,
                Message = lesson == null ? "Ders Kaydedilemedi" : "Ders Başarıyla Eklendi"
            };
        }
    }
}
