using bidersGo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace bidersGo.Business.Abstract
{
    public interface IStudentService : IValidator<Student>
    {
        List<Teacher> GetTeachersAll();
    
       
        List<Lesson> GetLessonsAll();
        List<Meet> GetMeetsByTeacher(Teacher teacher);

        List<Meet> GetBetweenSelectedDateMeet(DateTime start, DateTime finish);
        List<Meet> GetLessonFinishTime(DateTime finish);
















    }

}

