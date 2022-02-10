using bidersGo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bidersGo.Business.Abstract
{
    public interface ITeacherService : IValidator<Teacher>
    {
        List<Student> GetAllStudents();
        
        List<Meet> GetBetweenSelectedDateMeet(DateTime start, DateTime finish);
        List<Teacher> GetAllTeachers();
        List<Meet> GetMeetsByStudent(Student student);
        
        
        List<Lesson> GetLessonsAll();





        public void ApproveMeet(Meet meet);



    }
}
