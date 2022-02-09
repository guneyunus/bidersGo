using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Business.Abstract;
using bidersGo.DataAcces.Abstract;
using bidersGo.DataAcces.Conctare;
using bidersGo.Entities;

namespace bidersGo.Business.Concrate
{
    public class AdminManager : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string ErrorMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

        public List<Student> GetAllStudent()
        {
            return _unitOfWork.StudentRepository.GetStudentsAll();
        }

        public bool Validation(Admin entity)
        {
            throw new NotImplementedException();
        }
    }
}
