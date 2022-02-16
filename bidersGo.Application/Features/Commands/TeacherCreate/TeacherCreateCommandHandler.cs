using AutoMapper;
using bidersGo.Application.Interfaces.UnitOfWork;
using bidersGo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.TeacherCreate
{
    public class TeacherCreateCommandHandler:IRequestHandler<TeacherCreateCommandRequest,TeacherCreateCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        

        public TeacherCreateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
                
        }

        public async Task<TeacherCreateCommandResponse> Handle(TeacherCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var NewTeacher = new Teacher() 
            {
                Name=request.Name,
                Surname=request.Surname,
                TcKimlik=request.TcKimlik,
                Email=request.Email,
                NickName=request.NickName,
                Password=request.Password
            };
            var teacher = _unitOfWork.TeacherRepository.CreateAsync(NewTeacher);
            return new TeacherCreateCommandResponse() 
            {
                Succeed=teacher==null?false:true,
                Message="Kayıt işlemi başarıyla gerçekleşti"
            };
        }
    }
}
