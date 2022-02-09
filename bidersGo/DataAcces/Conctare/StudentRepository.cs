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
            return _context.Students.Where(x => x.Id == StudentGuid).FirstOrDefault();
        }

        public Student GetStudentByName(string Name)
        {
            return _context.Students.Where(x => x.Name == Name).FirstOrDefault();
        }

        public List<Student> GetStudentsAll()
        {
            return _context.Students.ToList();
        }

    }
}
