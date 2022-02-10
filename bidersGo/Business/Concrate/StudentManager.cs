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
    public class StudentManager : IStudentService
    {
        private IUnitOfWork _unitOfWork;
        public StudentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string ErrorMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<Lesson> GetLessonsAll()
        {
            return _unitOfWork.LessonRepository.GetLessonsAll();

        }

        public List<Meet> GetMeetsByTeacher(Teacher teacher)
        {
            return _unitOfWork.MeetRepository.GetMeetsByTeachers(teacher.Id).ToList();

        }

       

        public List<Teacher> GetTeachersAll()
        {
            return _unitOfWork.TeacherRepository.GetTeachersAll();
        }

        public bool Validation(Student entity)
        {
            throw new NotImplementedException();
        }
    }
        
}
