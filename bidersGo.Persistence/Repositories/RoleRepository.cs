using bidersGo.Application.Interfaces.Repositories;
using bidersGo.Domain.Entities.Identity;
using bidersGo.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Persistence.Repositories
{
    public class RoleRepository : GenericRepository<ApplicationRole>, IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public ApplicationRole GetRoleById(string UserId)
        {
            return _context.Roles.Where(x=>x.Id == UserId).FirstOrDefault();
        }

        public ApplicationRole GetRoleByName(string Name)
        {
            return _context.Roles.Where(x => x.Name == Name).FirstOrDefault();

        }

        public List<ApplicationRole> GetsAllRole()
        {
            return _context.Roles.ToList();
        }
    }
}
