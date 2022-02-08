using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Entities;

namespace bidersGo.DataAcces.Abstract
{
    public interface IAdminRepository : IRepository<Admin>
    {
        Student GetStudentByName(string StudentName);
        List<Student> GetStudentAll();
        Teacher GetTeacherByName(string TeacherName);
        List<Teacher> GetTeachersAll();
        Lesson GetLessonByName(string LessonName);
        List<Lesson> GetLessonsAll();
        List<Meet> GetMeetsByTeacher(Guid teacherGuid);
        List<Meet> GetMeetsByStudents(Guid studentGuid);
        List<Meet> GetMeetsByDate(DateTime dateStart,DateTime dateFinish);
        Moderator GetModerator(Guid moderatorGuid);
        List<Moderator> GetModeratorAll();


    }
}
