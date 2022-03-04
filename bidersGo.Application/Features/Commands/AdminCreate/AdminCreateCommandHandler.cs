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

namespace bidersGo.Application.Features.Commands.AdminCreate
{
    public class AdminCreateCommandHandler : IRequestHandler<AdminCreateCommandRequest, AdminCreateCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AdminCreateCommandHandler(IUnitOfWork unitOfWork,UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
            SetRoles();
        }

        private void SetRoles()
        {
            foreach (var roleName in RoleNames.Roles)
            {
                if (!_roleManager.RoleExistsAsync(roleName).Result)
                {
                    var result = _roleManager.CreateAsync(new ApplicationRole()
                    {
                        Name = roleName,
                    }).Result;
                }
            }
        }

        public async Task<AdminCreateCommandResponse> Handle(AdminCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                return new AdminCreateCommandResponse()
                {
                    Succeed = false,
                    Message = "Kayıt işleminde hata gerçekleşti. Bu email Adressi daha önce kullanılmıştır."
                };
            }

            var AdminUser = new ApplicationUser()
            {
                UserName = request.NickName,
                Email = request.Email,
                //Password = request.Password,
                EmailConfirmed = true
            };
            var UserSave = await _userManager.CreateAsync(AdminUser, request.Password);
            if (UserSave.Succeeded == false)
            {
                return new AdminCreateCommandResponse()
                {
                    Succeed = false,
                    Message = "Kayıt işleminde hata gerçekleşti"
                };
            }
            var count =  _userManager.Users.Count();
            _userManager.AddToRoleAsync(AdminUser, count <= 2 ? RoleNames.Admin : RoleNames.Passive);

            var NewAdmin = new Admin() 
            {
                Name=request.Name,
                Surname=request.Surname,
                Email=request.Email,
                NickName=request.NickName,
                //Password=request.Password,
                UserId = AdminUser.Id
            };
            var admin = _unitOfWork.AdminRepository.CreateAsync(NewAdmin);
            return new AdminCreateCommandResponse() 
            {
                Succeed=admin==null?false:true,
                Message="Kayıt işlemi başarıyla gerçekleşmiştir"
            };
        }
    }
}
