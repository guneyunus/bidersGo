using bidersGo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bidersGo.Business.Abstract
{
    public interface IModeratorService:IValidator<Moderator>
    {
        List<Student> GetAllStudents();
        List<Meet> GetAllMeets();

        List<Teacher> GetAllTeachers();

        List<Meet> GetMeetsByTeacher(Teacher teacher);

        List<Meet> GetMeetsByStudent(Student student);
        

        

        public void ApproveMeet(Meet meet);



    }
}
