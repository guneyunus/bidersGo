using bidersGo.Application.Interfaces.Repositories;
using bidersGo.Application.Interfaces.UnitOfWork;
using bidersGo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.StudentCreate
{
    public class StudentCreateCommandHandler : IRequestHandler<StudentCreateCommandRequest, StudentCreateCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentCreateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;

        }

        public async Task<StudentCreateCommandResponse> Handle(StudentCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var NewStudent = new Student()
            {
                Name = request.Name,
                Surname = request.Surname,
                TcKimlik = request.TcKimlik,
                Email = request.Email,
                NickName = request.NickName,
                Password = request.Password
            };

            var student = _unitOfWork.StudentRepository.CreateAsync(NewStudent);
            return new StudentCreateCommandResponse()
            {
                Succeed = student == null ? false : true,
                Message = "Kayıt Başarıyla Gerçekleşti"


            };
        }

    }
}
    

