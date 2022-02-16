using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.DataAcces.Abstract;
using bidersGo.Entities;

namespace bidersGo.DataAcces.Conctare
{
    public class MeetRepository : GenericRepository<Meet> , IMeetRepository
    {
        private readonly BidersGoContext _context;
        public MeetRepository(BidersGoContext context):base(context)
        {
            _context = context;
        }

        public List<Meet> GetMeetsAll()
        {
            return _context.Meets.ToList();
        }

        public Address GetMeetAdress(Guid meetGuid)
        {
            return _context.Meets.Where(x => x.Id == meetGuid).Select(x => x.Address).FirstOrDefault();
        }

        public List<Meet> GetMeetAll()
        {
           return _context.Meets.ToList();
        }

        public Meet GetMeetByDate(DateTime meetDateTime)
        {
            return _context.Meets.Where(x => x.LessonTime == meetDateTime).FirstOrDefault();
        }

        public Meet GetMeetByStudent(Guid studentGuid)
        {
            return _context.Meets.Where(x => x.Id == studentGuid).FirstOrDefault();
        }

        public Meet GetMeetByTeacher(Guid teacherGuid)
        {
            return _context.Meets.Where(x => x.Id == teacherGuid).FirstOrDefault();

        }

        public Lesson GetMeetLesson(Guid lessonGuid)
        {
            return _context.Meets.Where(x => x.Id == lessonGuid).Select(x=>x.Lesson).FirstOrDefault();
        }

        public List<Meet> GetMeetsByDate(DateTime dateStart, DateTime dateFinish)
        {
            return _context.Meets.Where(x => x.LessonTime > dateStart && x.LessonFinishTime < dateFinish).ToList();
        }

        public List<Meet> GetMeetsByStudents(Guid studentGuid)
        {
            return _context.Meets.Where(x => x.StudentId == studentGuid).ToList();
        }

        public List<Meet> GetMeetsByTeachers(Guid teacherGuid)
        {
            return _context.Meets.Where(x => x.TeacherId == teacherGuid).ToList();
        }

        public Student GetStudentOnMeet(Guid meetGuid)
        {
            return _context.Meets.Where(x => x.Id == meetGuid).Select(x => x.Student).FirstOrDefault();
        }

        public List<Student> GetStudentsOnMeetNow(DateTime meetDate)
        {
            return _context.Students.Where(x => x.CreatedDate == meetDate).ToList();
        }

        public List<Teacher> GetTeachersOnMeetNow(DateTime meetDate)
        {
            return _context.Teachers.Where(x => x.CreatedDate == meetDate).ToList();

        }

        public List<Meet> GetLessonFinishTime(DateTime dateFinish)
        {
            throw new NotImplementedException();
        }
    }
}
