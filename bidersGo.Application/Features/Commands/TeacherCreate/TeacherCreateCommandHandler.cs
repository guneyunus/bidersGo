using AutoMapper;
using bidersGo.Application.Features.Queries.AddressGetAll;
using bidersGo.Application.Features.Queries.AddressGetById;
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


namespace bidersGo.Application.Features.Commands.TeacherCreate
{
    public class TeacherCreateCommandHandler:IRequestHandler<TeacherCreateCommandRequest,TeacherCreateCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public TeacherCreateCommandHandler(IUnitOfWork unitOfWork,UserManager<ApplicationUser> userManager,RoleManager<ApplicationRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<TeacherCreateCommandResponse> Handle(TeacherCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                return new TeacherCreateCommandResponse()
                {
                    Succeed = false,
                    Message = "Kayıt işleminde hata gerçekleşti. Bu email Adressi daha önce kullanılmıştır."
                };
            }
            if (request.Password != request.ConfirmPassword)
            {
                return new TeacherCreateCommandResponse()
                {
                    Succeed = false,
                    Message = "Kayıt işleminde hata gerçekleşti şifreler uyuşmuyor."
                };

            }
            var TeacherUser = new ApplicationUser()
            {
                UserName = request.UserName,
                Email = request.Email,
               //Password = request.Password,
                EmailConfirmed = true
            };
            var UserKaydet = await _userManager.CreateAsync(TeacherUser,request.Password);
            if (UserKaydet.Succeeded == false)
            {
                return new TeacherCreateCommandResponse()
                {
                    Succeed =  false ,
                    Message = "Kayıt işleminde hata gerçekleşti" 
                };
            }
            _userManager.AddToRoleAsync(TeacherUser, RoleNames.Passive);

            var NewTeacher = new Teacher() 
            {
                Name=request.Name,
                Surname=request.Surname,
                TcKimlik= request.TcKimlik,
                Email=request.Email,
                NickName=request.NickName,
                //Password=request.Password,
                Branch = request.Branch,
                LessonId= request.LessonId,
                Address = new Address() {State= request.State },
                UserId = TeacherUser.Id
                
            };
            var teacher = _unitOfWork.TeacherRepository.CreateAsync(NewTeacher);
            if(teacher!=null)
                _unitOfWork.SaveAsync();
            return new TeacherCreateCommandResponse() 
            {
                Succeed=teacher==null?false:true,
                Message= teacher == null ? "Kayıt işleminde hata gerçekleşti" : "Kayıt işlemi başarıyla gerçekleşti"
            };
        }
    }
}
