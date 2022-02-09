using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Entities;
using bidersGo.Models.Identity;

namespace bidersGo.Business.Abstract
{
    public interface IAdminService :IValidator<Admin>
    {
        //busines logic for admin
        List<Student> GetAllStudent();
        List<Teacher> GetAllTeacher();
        List<Meet> GetAllMeet();
        List<Meet> GetBetweenSelectedDateMeet(DateTime start, DateTime finish);
        List<Moderator> GetAllModerator();
        List<Lesson> GetAllLesson();
        void UpdateRole();
        void AssigneRole();
        void DeleteUser(ApplicationUser user);
        void UpdateUser(ApplicationUser user);


        void CreateMeet(Teacher teacher,Student student,Lesson lesson,Address address,DateTime startTime,DateTime finishTime);
    }
}
