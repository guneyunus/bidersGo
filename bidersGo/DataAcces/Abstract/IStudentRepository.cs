using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Entities;

namespace bidersGo.DataAcces.Abstract
{
    public interface IStudentRepository : IRepository<Student>
    {
        List<Student> GetStudentsAll();
        Student GetStudentById(Guid StudentGuid);
        Student GetStudentByName(string Name);
        Address GetStudentAdress(Student Student);
        












    }
}
