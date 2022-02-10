using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.DataAcces.Abstract;
using bidersGo.Entities;

namespace bidersGo.DataAcces.Conctare
{
    public class TeacherRepository:GenericRepository<Teacher>,ITeacherRepository
    {
        private readonly BidersGoContext _context;

        public TeacherRepository(BidersGoContext context):base(context)
        {
            _context = context;
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
