using bidersGo.Application.Interfaces.UnitOfWork;
using bidersGo.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.RoleUpdate
{
    public class RoleUpdateCommandHandler : IRequestHandler<RoleUpdateCommandRequest, RoleUpdateCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public RoleUpdateCommandHandler(IUnitOfWork unitOfWork,UserManager<ApplicationUser> userManager,RoleManager<ApplicationRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<RoleUpdateCommandResponse> Handle(RoleUpdateCommandRequest request, CancellationToken cancellationToken)
        {

            var user = _unitOfWork.UserRepository.GetUserById(request.Id);
            
            var userRoles = await _userManager.GetRolesAsync(user);

            var removed = await _userManager.RemoveFromRoleAsync(user, userRoles.First());

            if (removed.Succeeded)
            {
                foreach (var item in RoleNames.Roles)
                {
                    if (item == request.Name)
                    {
                     await _userManager.AddToRoleAsync(user, item);
                    }
                }
            }
            else
            {
                return new RoleUpdateCommandResponse()
                {
                    Succeed = false ,
                    Message = "Kulanıcı Role Güncelleme işleminde hata gerçekleşti!"
                };

            }
            _unitOfWork.Save();

            return new RoleUpdateCommandResponse()
            {
                Succeed = true,
                Message =  "Kullanıcı Role Güncelleme işlemi başarıyla gerçekleşti"
            };
        }
    }
}
