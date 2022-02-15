using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using bidersGo.Application.Interfaces.Repositories;
using bidersGo.Domain.Entities;
using bidersGo.Persistence.Context;

namespace bidersGo.DataAcces.Conctare
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        private readonly ApplicationDbContext _context;
        public AdminRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public Lesson GetLessonByName(string LessonName)
        {
            return _context.Lessons.Where(x=>x.LessonName == LessonName).FirstOrDefault();
        }

        public List<Lesson> GetLessonsAll()
        {
            return _context.Lessons.ToList();
        }

        public List<Meet> GetMeetsByDate(DateTime dateStart, DateTime dateFinish)
        {
            return _context.Meets.Where(x => x.LessonTime > dateStart && x.LessonFinishTime < dateFinish).ToList();
        }

        public List<Meet> GetMeetsByStudents(Guid studentGuid)
        {
            return _context.Meets.Where(x => x.StudentId == studentGuid).ToList();
        }

        public List<Meet> GetMeetsByTeacher(Guid teacherGuid)
        {
            return _context.Meets.Where(x => x.TeacherId == teacherGuid).ToList();
        }

        public List<Student> GetStudentAll()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentByName(string StudentName)
        {
            return _context.Students.Where(x => x.Name == StudentName).FirstOrDefault();
        }

        public Teacher GetTeacherByName(string TeacherName)
        {
            return _context.Teachers.Where(x => x.Name == TeacherName).FirstOrDefault();
        }

        public List<Teacher> GetTeachersAll()
        {
            return _context.Teachers.ToList();
        }

        public Moderator GetModerator(Guid moderatorGuid)
        {
            return _context.Moderators.Where(x => x.Id == moderatorGuid).FirstOrDefault();
        }

        public List<Moderator> GetModeratorAll()
        {
            return _context.Moderators.ToList();
        }

        public List<Admin> GetAdminAll()
        {
            return _context.Admins.ToList();

        }
    }
}
