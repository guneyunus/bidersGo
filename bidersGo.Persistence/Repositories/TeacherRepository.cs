using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Application.Interfaces.Repositories;
using bidersGo.Domain.Entities;
using bidersGo.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace bidersGo.Persistence.Repositories
{
    public class TeacherRepository:GenericRepository<Teacher>,ITeacherRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public void CreateWorkingForOneHour(WorkingForOneHour hour)
        {
            _context.workingForOneHours.Add(hour);
            _context.SaveChanges();
        }

        public void CreateWorkingForWeek(WorkingHoursOfWeek hour)
        {
            _context.WorkingHoursOfWeeks.Add(hour);
            _context.SaveChanges();
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

        public Teacher GetTeacherByWorkingTableId(Guid id)
        {
            return _context.WorkingHoursOfWeeks.Where(x => x.Id == id).Select(x => x.Teacher).FirstOrDefault();
            
        }

        public List<Teacher> GetTeachersAll()
        {
            return _context.Teachers.ToList();
        }

        public WorkingHoursOfWeek GetWorkingTable(Guid id)
        {
            return _context.WorkingHoursOfWeeks.Where(x => x.Id == id).First();
        }
    }
}
