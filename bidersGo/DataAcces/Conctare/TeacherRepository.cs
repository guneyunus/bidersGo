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
            throw new NotImplementedException();
        }

        public Teacher GetTeacherByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Teacher> GetTeachersAll()
        {
            throw new NotImplementedException();
        }
    }
}
