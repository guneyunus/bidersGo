using bidersGo.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        List<ApplicationUser> GetUsersAll();
        ApplicationUser GetUserById(string UserId);
        ApplicationUser GetUserByUserName(string Name);
        ApplicationUser GetUserByEmail(string email);
    }
}
