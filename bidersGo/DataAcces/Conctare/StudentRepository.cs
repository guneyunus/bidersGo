using bidersGo.DataAcces.Abstract;
using bidersGo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bidersGo.DataAcces.Conctare
{
    public class StudentRepository:GenericRepository<Student>,IStudentRepository
    {
        private readonly BidersGoContext _context;

        public StudentRepository(BidersGoContext context) : base(context)
        {
            _context = context;
        }

        public Address GetStudentAdress(Student Student)
        {
            return _context.Addresses.Where(x => x.Id == Student.Address.Id).FirstOrDefault();
        }

        public Student GetStudentById(Guid StudentGuid)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetStudentsAll()
        {
            throw new NotImplementedException();
        }

        public List<Student> GetStudentsWithAllLessons()
        {
            throw new NotImplementedException();
        }

        public List<Student> GetStudentsWithAllMeets()
        {
            throw new NotImplementedException();
        }
    }
}
