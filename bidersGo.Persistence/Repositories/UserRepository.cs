using bidersGo.Application.Interfaces.Repositories;
using bidersGo.Domain.Entities.Identity;
using bidersGo.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Persistence.Repositories
{
    public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public ApplicationUser GetUserByEmail(string email)
        {
            return _context.Users.Where(x => x.Email == email).FirstOrDefault();
        }

        public ApplicationUser GetUserById(string UserId)
        {
            return _context.Users.Where(x=>x.Id == UserId).FirstOrDefault();
        }

        public ApplicationUser GetUserByUserName(string Name)
        {
            return _context.Users.Where(x => x.UserName == Name).FirstOrDefault();
        }

        public List<ApplicationUser> GetUsersAll()
        {
            return _context.Users.ToList();
        }
    }
}
