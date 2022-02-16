using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Domain.Entities;

namespace bidersGo.Application.Interfaces.Repositories
{
    public interface IModeratorRepository : IRepository<Moderator>
    {
        List<Moderator> GetModeratorAll();
        Student GetStudentById(Guid StudentGuid);
        Student GetStudentByName(string Name);
        List<Student> GetStudentsAll();
        Address GetStudentAdress(Student Student);
        List<Meet> GetStudentMeet(Student Student);
        Teacher GetTeacherById(Guid TeacherGuid);
        Teacher GetTeacherByName(string TeacherName);
        List<Teacher> GetAllTeacher();
        Address GetAddress(Teacher teacher);
        List<Meet> GetTeacherMeet(Teacher teacher);
        Moderator GetModeratorById(Guid moderatorGuid);
        List<Meet> GetMeetNow();
        Meet GetMeetById(Guid MeetGuid);
        DateTime GetMeetDateTime(Meet Meet);
        void CreateMeet(Meet meet);











    }
}
