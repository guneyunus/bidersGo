using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Entities;

namespace bidersGo.DataAcces.Abstract
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        List<Teacher> GetTeachersAll();
        Teacher GetTeacherById(Guid teacherGuid);
        Teacher GetTeacherByName(string Name);
        Address GetTeacherAdress(Teacher teacher);
        

    }
}
