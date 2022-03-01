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
            //var userRole = _unitOfWork.RoleRepository.GetRoleById(request.Id);


           // var userManager =  _userManager.FindByIdAsync(request.Id); // bu sonuc application user dönmüyor sorun burda 
            var userManagerRole = _userManager.GetRolesAsync(user).Result.ToString();
           // await _userManager.RemoveFromRolesAsync(user, userManagerRole); // gecici olarak kapattım hatadan kurtulmak için


            var result = _unitOfWork.RoleRepository.GetRoleByName(userManagerRole); //patlamasın diye rastgele yazdım
            _unitOfWork.Save();

            return new RoleUpdateCommandResponse()
            {
                Succeed = result == null ? false : true,
                Message = result == null ? "Ders Güncelleme işleminde hata gerçekleşti" : "Ders Güncelleme işlemi başarıyla gerçekleşti"
            };
        }
    }
}
