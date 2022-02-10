using bidersGo.Business.Abstract;
using bidersGo.DataAcces.Abstract;
using bidersGo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bidersGo.Business.Concrate
{
    public class ModeratorManager : IModeratorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ModeratorManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string ErrorMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ApproveMeet(Meet meet)
        {
            meet.IsApproved = true;
            _unitOfWork.MeetRepository.Create(meet);
            _unitOfWork.Save();
            _unitOfWork.Dispose();

        }

        public List<Student> GetAllStudents()
        {
            return _unitOfWork.StudentRepository.GetStudentsAll();
        }

        public List<Teacher> GetAllTeachers()
        {
            return _unitOfWork.TeacherRepository.GetTeachersAll();
        }

       public List<Meet> GetAllMeets()
        {
            return _unitOfWork.MeetRepository.GetMeetsAll();
        }
       

        public bool Validation(Moderator entity)
        {
            throw new NotImplementedException();
        }

        public List<Meet> GetMeetsByTeacher(Teacher teacher)
        {
            return _unitOfWork.MeetRepository.GetMeetsByTeachers(teacher.Id).ToList();
        }

        public List<Meet> GetMeetsByStudent(Student student)
        {
            return _unitOfWork.MeetRepository.GetMeetsByStudents(student.Id).ToList();
        }

        public List<Meet> GetBetweenSelectedDateMeet(DateTime start, DateTime finish)
        {
            return _unitOfWork.MeetRepository.GetMeetsByDate(start,finish);

        }
    }
}
