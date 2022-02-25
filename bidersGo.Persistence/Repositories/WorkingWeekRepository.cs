using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidersGo.Application.Interfaces.Repositories;
using bidersGo.Domain.Entities;
using bidersGo.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace bidersGo.Persistence.Repositories
{
    public class WorkingWeekRepository : GenericRepository<WorkingHoursOfWeek>, IWorkingWeekRepository
    {
        private readonly ApplicationDbContext _context;
        public WorkingWeekRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public WorkingHoursOfWeek WorkingHoursOfWeek(Guid Id)
        {
            return _context.WorkingHoursOfWeeks
                .Include(x=>x.WorkingForOneHours)
                .ThenInclude(x => x.week)
                .Where(x => x.Id == Id).First();
        }
    }
}
