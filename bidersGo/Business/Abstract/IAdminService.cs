using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Entities;

namespace bidersGo.Business.Abstract
{
    public interface IAdminService :IValidator<Admin>
    {
        //busines logic for admin
        List<Student> GetAllStudent();
        List<Teacher> GetAllTeacher();

        void CreateMeet(Teacher teacher,Student student,Lesson lesson,Address address,DateTime startTime,DateTime finishTime);
    }
}
