using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.TeacherUpdate
{
    public class TeacherUpdateCommandHandler : IRequestHandler<TeacherUpdateCommandRequest, TeacherUpdateCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public TeacherUpdateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
                
        }
        public async Task<TeacherUpdateCommandResponse> Handle(TeacherUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var teacher = _unitOfWork.TeacherRepository.GetById(request.Id);
            teacher.Name = request.Name;
            teacher.Surname = request.Surname;
            teacher.Email = request.Email;
            teacher.Address = request.Address;
            teacher.NickName = request.NickName;
            //teacher.Password = request.Password;

           var result= _unitOfWork.TeacherRepository.AsyncUpdate(teacher);
            _unitOfWork.Save();
            return new TeacherUpdateCommandResponse()
            {
                Succeed = result == null ? false : true,
                Message = result == null ? "Öğretmen Güncelleme işleminde hata gerçekleşti" : "Öğretmen Güncelleme işlemi başarıyla gerçekleşti"
            };


        }
    }
}
