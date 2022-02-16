using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Application.Interfaces.Repositories;
using bidersGo.Domain.Entities;
using bidersGo.Persistence.Context;

namespace bidersGo.Persistence.Repositories
{
    public class TeacherRepository:GenericRepository<Teacher>,ITeacherRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public List<WorkingHoursOfWeek> GetMeetForWeek()
        {
            return _context.WorkingHoursOfWeeks.ToList();
        }

        public Address GetTeacherAdress(Teacher teacher)
        {
            return _context.Addresses.Where(x => x.Id == teacher.Address.Id).FirstOrDefault();
        }

        public Teacher GetTeacherById(Guid teacherGuid)
        {
            return _context.Teachers.Where(x => x.Id == teacherGuid).FirstOrDefault();
        }

        public Teacher GetTeacherByName(string Name)
        {
            return _context.Teachers.Where(x => x.Name == Name).FirstOrDefault();
        }

        public List<Teacher> GetTeachersAll()
        {
            return _context.Teachers.ToList();
        }
    }
}
