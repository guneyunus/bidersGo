using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Entities;

namespace bidersGo.DataAcces.Abstract
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        List<Teacher> GetStudentsAll();
        Teacher GetStudentById(Guid teacherGuid);
        Teacher GetStudentByName(string Name);
        Address GetStudentAdress(Teacher teacher);
        

    }
}
