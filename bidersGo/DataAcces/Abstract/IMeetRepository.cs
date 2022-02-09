using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Entities;

namespace bidersGo.DataAcces.Abstract
{
    public interface IMeetRepository:IRepository<Meet>
    {
        List<Meet> GetMeetAll();
        List<Meet> GetMeetsByTeacher(Guid teacherGuid);
        List<Meet> GetMeetsByStudents(Guid studentGuid);
        List<Meet> GetMeetsByDate(DateTime dateStart, DateTime dateFinish);
        Address GetMeetAdress(Guid meetGuid);
        Lesson GetMeetLesson(Guid lessonGuid);
        Meet GetMeetByTeacher(Guid teacherGuid);
        Meet GetMeetByStudent(Guid studentGuid);
        Meet GetMeetByDate(DateTime meetDateTime);
        Student GetStudentOnMeet(Guid meetGuid);
        List<Student> GetStudentsOnMeetNow(DateTime meetDate);
        List<Teacher> GetTeachersOnMeetNow(DateTime meetDate);
        
    }
}
