using bidersGo.Application.Interfaces.UnitOfWork;
using bidersGo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.TeacherDelete
{

    public class TeacherDeleteCommandHandler : IRequestHandler<TeacherDeleteCommandRequest, TeacherDeleteCommandResponse>
    {

        private readonly IUnitOfWork _unitOfWork;
        public TeacherDeleteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<TeacherDeleteCommandResponse> Handle(TeacherDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            var teacher = _unitOfWork.TeacherRepository.GetById(request.Id);
       
            _unitOfWork.TeacherRepository.Delete(teacher);
            _unitOfWork.Save();

            var model = new TeacherDeleteCommandResponse();

            if (_unitOfWork.TeacherRepository.GetById(request.Id) == null)
            {
                model.Succeed = true;
            }

            if (model.Succeed == true)
            {
                model.Message = "Öğretmen kaydı başarıyla silindi";
            }
            else
            {
                model.Message = "Öğretmen kaydı silme başarısız";
            }
            return Task<TeacherDeleteCommandResponse>.FromResult(model);

        }
    }
}
