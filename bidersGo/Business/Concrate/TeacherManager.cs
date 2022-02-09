using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Business.Abstract;
using bidersGo.DataAcces.Abstract;
using bidersGo.DataAcces.Conctare;
using bidersGo.Entities;
using bidersGo.Models.Identity;

namespace bidersGo.Business.Concrate
{
    public class TeacherManager : ITeacherService
    {
        private IUnitOfWork _unitOfWork;
        public TeacherManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public string ErrorMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ApproveMeet(Meet meet)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetAdminAll()
        {
            return _unitOfWork.AdminRepository.GetAdminAll();

        }

        public List<Meet> GetAllMeets()
        {
            return _unitOfWork.MeetRepository.GetMeetAll();

        }

        public List<Student> GetAllStudents()
        {
            return _unitOfWork.StudentRepository.GetStudentsAll();

        }

        public List<Teacher> GetAllTeachers()
        {
            return _unitOfWork.TeacherRepository.GetTeachersAll();

        }

        public List<Meet> GetBetweenSelectedDateMeet(DateTime start, DateTime finish)
        {
            return _unitOfWork.MeetRepository.GetMeetsByDate(start,finish);

        }

        public List<Lesson> GetLessonsAll()
        {
            return _unitOfWork.LessonRepository.GetLessonsAll();

        }

        public List<Meet> GetMeetsByStudent(Student student)
        {
            return _unitOfWork.MeetRepository.GetMeetsByStudents(student.Id).ToList();

        }

        public List<Moderator> GetModeratorAll()
        {
            return _unitOfWork.ModeratorRepository.GetModeratorAll();

        }

        public bool Validation(Teacher entity)
        {
            throw new NotImplementedException();
        }
    }
}
