using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Application.Interfaces.Repositories;
using bidersGo.Domain.Entities;

namespace bidersGo.Application.Interfaces.Repositories
{
    public interface IAdminRepository : IRepository<Admin>
    {
        List<Admin> GetAdminAll();
        Admin GetAdminById(Guid adminGuid);
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
