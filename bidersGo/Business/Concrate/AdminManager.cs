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
    public class AdminManager : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string ErrorMessage { get; set ; }

        public void AssigneRole()
        {
            throw new NotImplementedException();
        }

        public void CreateMeet(Teacher teacher, Student student, Lesson lesson,Address address,DateTime starTime,DateTime finishTime)
        {
            var Teacher = _unitOfWork.TeacherRepository.GetTeacherById(teacher.Id);
            var Student = _unitOfWork.StudentRepository.GetStudentById(student.Id);
            var Lesson = _unitOfWork.LessonRepository.GetLessonWithDetails(lesson.LessonName);
            var Adresss = _unitOfWork.AddressRepository.GetSelectedAdress(address);
            var createMeet = new Meet
            {
                Teacher = Teacher,
                Student = Student,
                Lesson = Lesson,
                Address = Adresss,
                LessonTime = starTime,
                LessonFinishTime = finishTime
            };
            
            _unitOfWork.MeetRepository.Create(createMeet);
            _unitOfWork.Save();
            _unitOfWork.Dispose();
        }

        public void DeleteUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public List<Lesson> GetAllLesson()
        {
          return  _unitOfWork.LessonRepository.GetLessonsAll();
        }

        public List<Meet> GetAllMeet()
        {
            return _unitOfWork.MeetRepository.GetMeetAll();

        }

        public List<Moderator> GetAllModerator()
        {
            return _unitOfWork.ModeratorRepository.GetModeratorAll();
        }

        public List<Student> GetAllStudent()
        {
            return _unitOfWork.StudentRepository.GetStudentsAll();
        }

        public List<Teacher> GetAllTeacher()
        {
            return _unitOfWork.TeacherRepository.GetTeachersAll();
        }

        public List<Meet> GetBetweenSelectedDateMeet(DateTime start,DateTime finish)
        {
            return _unitOfWork.MeetRepository.GetMeetsByDate(start,finish);
        }

        public void UpdateRole()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public bool Validation(Admin entity)
        {
            throw new NotImplementedException();
        }
    }
}
