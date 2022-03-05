using bidersGo.Application.Interfaces.Repositories;
using bidersGo.Domain.Entities;
using bidersGo.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bidersGo.Persistence.Repositories
{
    public class StudentRepository:GenericRepository<Student>,IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Address GetStudentAdress(Student student)
        {
            return _context.Addresses.Where(x => x.Id == student.Address.Id).FirstOrDefault();
        }

        public Student GetStudentById(Guid StudentGuid)
        {
            return _context.Students.Where(x => x.Id == StudentGuid).FirstOrDefault();
        }

        public Student GetStudentByName(string Name)
        {
            return _context.Students.Where(x => x.Name == Name).FirstOrDefault();
        }
        
        public Student GetStudentByUserId(string id)
        {
            return _context.Students.FirstOrDefault(x => x.UserId == id);
        }

        public List<Student> GetStudentsAll()
        {
            return _context.Students.ToList();
        }

    }
}
