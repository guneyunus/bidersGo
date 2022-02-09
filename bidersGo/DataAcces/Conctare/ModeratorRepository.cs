using bidersGo.DataAcces.Abstract;
using bidersGo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bidersGo.DataAcces.Conctare
{
    public class ModeratorRepository : GenericRepository<Moderator> ,IModeratorRepository
    {
        private readonly BidersGoContext _context;
        public ModeratorRepository(BidersGoContext context): base(context)
        {
            _context = context;
        }

        public void CreateMeet(Meet meet)
        {
            var CreatedMeet = meet;
            CreatedMeet.IsApproved = true;
            _context.Meets.Add(CreatedMeet);
        }

        public Address GetAddress(Teacher teacher)
        {
            return _context.Teachers.Where(x=>x.Id == teacher.Id).Select(x=>x.Address).FirstOrDefault();
        }

        public List<Teacher> GetAllTeacher()
        {
            return _context.Teachers.ToList();
        }

        public Meet GetMeetById(Guid MeetGuid)
        {
            return _context.Meets.Where(x=>x.Id==MeetGuid).FirstOrDefault();
        }

        public DateTime GetMeetDateTime(Meet Meet)
        {
            return _context.Meets.Where(x=>x.Id==Meet.Id).Select(x=>x.LessonTime).FirstOrDefault();
        }

        public List<Meet> GetMeetNow()
        {
            //return _context.Meets.Where(x=>x.LessonTime.Hour == DateTime.Now.Hour || x.LessonFinishTime > DateTime.Now).ToList();
            return _context.Meets.Where(x=>x.LessonFinishTime > DateTime.Now).ToList();
        }

        public Address GetStudentAdress(Student Student)
        {
            return _context.Students.Where(x=>x.Id== Student.Id).Select(x=>x.Address).FirstOrDefault();
        }

        public Student GetStudentById(Guid StudentGuid)
        {
            return _context.Students.Where(x=>x.Id == StudentGuid).FirstOrDefault();
        }

        public Student GetStudentByName(string Name)
        {
            return _context.Students.Where(x=>x.Name==Name).FirstOrDefault();
        }

        public List<Meet> GetStudentMeet(Student Student)
        {
          return  _context.Meets.Where(x=>x.Student==Student).ToList();

        }

        public List<Student> GetStudentsAll()
        {
            return _context.Students.ToList();
        }

        public Teacher GetTeacherById(Guid TeacherGuid)
        {
            return _context.Teachers.Where(x=>x.Id==TeacherGuid).FirstOrDefault();
        }

        public Teacher GetTeacherByName(string TeacherName)
        {
            return _context.Teachers.Where(x=>x.Name == TeacherName).FirstOrDefault();
        }

        public List<Meet> GetTeacherMeet(Teacher teacher)
        {
            return _context.Meets.Where(x=>x.Teacher==teacher).ToList();
        }
    }
}
