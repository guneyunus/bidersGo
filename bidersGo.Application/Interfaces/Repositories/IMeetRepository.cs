using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Domain.Entities;

namespace bidersGo.Application.Interfaces.Repositories
{
    public interface IMeetRepository:IRepository<Meet>
    {
        List<Meet> GetMeetAll();
        List<Meet> GetMeetsByTeachers(Guid teacherGuid);
        List<Meet> GetMeetsByStudents(Guid studentGuid);
        List<Meet> GetMeetsByDate(DateTime dateStart, DateTime dateFinish);
        List<Meet> GetMeetsAll();
        Address GetMeetAdress(Guid meetGuid);
        //Lesson GetMeetLesson(Guid lessonGuid);
        Meet GetMeetByMeetId(Guid id);
        Meet GetMeetByTeacher(Guid teacherGuid);
        Meet GetMeetByStudent(Guid studentGuid);
        Meet GetMeetByDate(DateTime meetDateTime);
        Student GetStudentOnMeet(Guid meetGuid);
        List<Student> GetStudentsOnMeetNow(DateTime meetDate);
        List<Teacher> GetTeachersOnMeetNow(DateTime meetDate);
        
    }
}
