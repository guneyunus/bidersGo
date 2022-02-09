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

        public void CreateMeet(Student student, Teacher teacher, Meet meet)
        {
            throw new NotImplementedException();
        }

        public Address GetAddress(Teacher teacher)
        {
            return _context.Teachers.Where(x=>x.Id == teacher.Id).Select(x=>x.Address).FirstOrDefault();
        }

        public List<Teacher> GetAllTeacher()
        {
            throw new NotImplementedException();
        }

        public Meet GetMeetById(Guid MeetGuid)
        {
            throw new NotImplementedException();
        }

        public DateTime GetMeetDateTime(Meet Meet)
        {
            throw new NotImplementedException();
        }

        public List<Meet> GetMeetNow()
        {
            throw new NotImplementedException();
        }

        public Address GetStudentAdress(Student Student)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentById(Guid StudentGuid)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Meet> GetStudentMeet(Student Student)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetStudentsAll()
        {
            throw new NotImplementedException();
        }

        public Teacher GetTeacherById(Guid TeacherGuid)
        {
            throw new NotImplementedException();
        }

        public Teacher GetTeacherByName(string TeacherName)
        {
            throw new NotImplementedException();
        }

        public List<Meet> GetTeacherMeet(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
