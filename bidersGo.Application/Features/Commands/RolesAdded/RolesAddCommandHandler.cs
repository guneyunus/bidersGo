using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using bidersGo.Application.Interfaces.UnitOfWork;
using bidersGo.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace bidersGo.Application.Features.Commands.RolesAdded
{
    public class RolesAddCommandHandler : IRequestHandler<RolesAddCommandRequest, RolesAddCommandResponse>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RolesAddCommandHandler(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public Task<RolesAddCommandResponse> Handle(RolesAddCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = false;

            RoleNames.Roles.Add(request.RoleName);
            foreach (var roleName in RoleNames.Roles)
            {
                if (!_roleManager.RoleExistsAsync(roleName).Result)
                {
                    var response = _roleManager.CreateAsync(new ApplicationRole()
                    {
                        Name = request.RoleName,
                    }).Result;
                    if (response.Succeeded) result = true;

                }
            }

            if (result == true)
            {
                return Task.FromResult(new RolesAddCommandResponse()
                {
                    Message = "role başarıyla eklenmiştir",
                    Succed = true
                });
            }
            else
            {
                return Task.FromResult(new RolesAddCommandResponse()
                {
                    Message = "role eklerken hata!",
                    Succed = false
                });
            }

        }
    }
}
