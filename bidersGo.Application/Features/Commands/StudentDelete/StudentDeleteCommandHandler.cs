using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.StudentDelete
{
    public class StudentDeleteCommandHandler : IRequestHandler<StudentDeleteCommandRequest, StudentDeleteCommandResponse>
    {
        private IUnitOfWork _unitOfWork;
        public StudentDeleteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<StudentDeleteCommandResponse> Handle(StudentDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            var student = _unitOfWork.StudentRepository.GetById(request.Id);

            _unitOfWork.StudentRepository.Delete(student);
            _unitOfWork.Save();

            var model = new StudentDeleteCommandResponse();
            if (_unitOfWork.StudentRepository.GetById(request.Id) == null)
            {
                model.Succeed = true;
            }
            if (model.Succeed == true)
            {
                model.Message = "Öğrenci Kaydı Başarıyla Silindi";
            }
            else
            {
                model.Message = "Öğrenci Kaydı Silinirken Hata Oluştu";
            }
            return Task<StudentDeleteCommandResponse>.FromResult(model);
            
        }
    }
}
