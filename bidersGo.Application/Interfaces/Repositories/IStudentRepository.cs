using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Domain.Entities;

namespace bidersGo.Application.Interfaces.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        List<Student> GetStudentsAll();
        Student GetStudentById(Guid StudentGuid);
        Student GetStudentByName(string Name);
        Address GetStudentAdress(Student student);

        Student GetStudentByUserId(Guid id);
    }
}
