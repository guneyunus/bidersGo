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

        public Address GetMeetAdress(Guid meetGuid)
        {
            return _context.Meets.Where(x => x.Id == meetGuid).Select(x => x.Address).FirstOrDefault();
        }

        public Meet GetMeetByDate(DateTime meetDateTime)
        {
            throw new NotImplementedException();
        }

        public Meet GetMeetByStudent(Guid studentGuid)
        {
            throw new NotImplementedException();
        }

        public Meet GetMeetByTeacher(Guid teacherGuid)
        {
            throw new NotImplementedException();
        }

        public Lesson GetMeetLesson(Guid lessonGuid)
        {
            throw new NotImplementedException();
        }

        public List<Meet> GetMeetsByDate(DateTime dateStart, DateTime dateFinish)
        {
            throw new NotImplementedException();
        }

        public List<Meet> GetMeetsByStudents(Guid studentGuid)
        {
            throw new NotImplementedException();
        }

        public List<Meet> GetMeetsByTeacher(Guid teacherGuid)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentOnMeet(Guid meetGuid)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetStudentsOnMeetNow(DateTime meetDate)
        {
            throw new NotImplementedException();
        }

        public List<Teacher> GetTeachersOnMeetNow(DateTime meetDate)
        {
            throw new NotImplementedException();
        }
    }
}
