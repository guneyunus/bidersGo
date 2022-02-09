using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Entities;

namespace bidersGo.DataAcces.Abstract
{
    public interface IModeratorRepository : IRepository<Moderator>
    {
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

        List<Meet> GetMeetNow();
        Meet GetMeetById(Guid MeetGuid);
        DateTime GetMeetDateTime(Meet Meet);
        void CreateMeet(Meet meet);











    }
}
