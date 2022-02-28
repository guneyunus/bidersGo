using bidersGo.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Interfaces.Repositories
{
    public interface IRoleRepository:IRepository<ApplicationRole>
    {
        List<ApplicationRole> GetsAllRole();
        ApplicationRole GetRoleById(string UserId);
        ApplicationRole GetRoleByName(string Name);
    }
}
