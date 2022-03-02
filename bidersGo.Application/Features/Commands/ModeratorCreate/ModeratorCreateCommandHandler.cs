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

namespace bidersGo.Application.Features.Commands.ModeratorCreate
{
  public  class ModeratorCreateCommandHandler:IRequestHandler<ModeratorCreateCommandRequest,ModeratorCreateCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public ModeratorCreateCommandHandler(IUnitOfWork unitOfWork,UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<ModeratorCreateCommandResponse> Handle(ModeratorCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                return new ModeratorCreateCommandResponse()
                {
                    Succeed = false,
                    Message = "Kayıt işleminde hata gerçekleşti. Bu email Adressi daha önce kullanılmıştır."
                };
            }
            var ModeratorUser = new ApplicationUser()
            {
                UserName = request.NickName,
                Email = request.Email,
                //Password = request.Password,
                EmailConfirmed = true
            };
            var UserSave = await _userManager.CreateAsync(ModeratorUser, request.Password);
            if (UserSave.Succeeded == false)
            {
                return new ModeratorCreateCommandResponse()
                {
                    Succeed = false,
                    Message = "Kayıt işleminde hata gerçekleşti"
                };
            }
            _userManager.AddToRoleAsync(ModeratorUser, RoleNames.Passive);

            var NewModerator = new Moderator() 
            {
                Name=request.Name,
                Surname=request.Surname,
                Email=request.Email,
                TcKimlik=request.TcKimlik,
                NickName=request.NickName,
                //Password=request.Password,
                UserId= ModeratorUser.Id
            };
            var moderator = _unitOfWork.ModeratorRepository.CreateAsync(NewModerator);
            _unitOfWork.Save();

            
            return new ModeratorCreateCommandResponse()
            {
                Succeed = moderator == null ? false : true,
                Message = moderator == null ? "Moderator Kayıt işleminde hata gerçekleşti" : "Moderator Kayıt işlemi başarıyla gerçekleşti"
            };
        }
    }
}
