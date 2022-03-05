using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.StudenUpdate
{
    public class StudentUpdateCommandHandler : IRequestHandler<StudentUpdateCommandRequest, StudentUpdateCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentUpdateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<StudentUpdateCommandResponse> Handle(StudentUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var student = _unitOfWork.StudentRepository.GetById(request.Id);

            student.Name = request.Name;
            student.Surname = request.Surname;
            student.Email = request.Email;
            student.Address = request.Address;
            student.NickName = request.NickName;
            student.TcKimlik = request.TcKimlik;
            //student.Password = request.Password;

            var result = _unitOfWork.StudentRepository.AsyncUpdate(student);
            _unitOfWork.Save();



            return new StudentUpdateCommandResponse()
            {
                Succeed = result == null ? false : true,
                Message = result == null ? "Öğrenci Güncelleme işleminde hata gerçekleşti" : "Öğrenci Güncelleme işlemi başarıyla gerçekleşti"
            };
        }
    }
}
