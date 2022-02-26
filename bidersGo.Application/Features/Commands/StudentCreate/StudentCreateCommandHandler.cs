using bidersGo.Application.Interfaces.Repositories;
using bidersGo.Application.Interfaces.UnitOfWork;
using bidersGo.Domain.Entities;
using bidersGo.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentCreateCommandHandler(IUnitOfWork unitOfWork,UserManager<ApplicationUser> userManager)
        {
            _unitOfWork=unitOfWork;
            _userManager=userManager;

        }

        public async Task<StudentCreateCommandResponse> Handle(StudentCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if(user != null)
            {
                return new StudentCreateCommandResponse()
                {
                    Succeed = false,
                    Message = "Kayıt işleminde hata gerçekleşti. Bu email Adressi daha önce kullanılmıştır."
                };
            }
            var StudentUser = new ApplicationUser()
            {
                UserName = request.NickName,
                Email = request.Email,
                Password = request.Password,
                EmailConfirmed = true
            };
            var UserSave = await _userManager.CreateAsync(StudentUser);
            if (UserSave.Succeeded == false)
            {
                return new StudentCreateCommandResponse()
                {
                    Succeed = false,
                    Message = "Kayıt işleminde hata gerçekleşti"
                };
            }
            _userManager.AddToRoleAsync(StudentUser, RoleNames.Passive);
            var NewStudent = new Student()
            {
                Name = request.Name,
                Surname = request.Surname,
                TcKimlik = request.TcKimlik,
                Email = request.Email,
                NickName = request.NickName,
                Password = request.Password,
                Address = new Address() { State = request.State},
                IsSearchLesson = request.IsSearchLesson,
                SubscriptionId = request.SubscriptionId,
                UserId = StudentUser.Id
            };

            var student = _unitOfWork.StudentRepository.CreateAsync(NewStudent);
            _unitOfWork.Save();
            return new StudentCreateCommandResponse()
            {
                Succeed = student == null ? false : true,
                Message = student == null ? "Öğrenci Kayıt işleminde hata gerçekleşti" : "Öğrenci Kayıt işlemi başarıyla gerçekleşti"


            };
        }

    }
}
    

