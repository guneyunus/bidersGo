using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Domain.Entities;

namespace bidersGo.Application.Interfaces.Repositories
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        List<Teacher> GetTeachersAll();
        Teacher GetTeacherById(Guid teacherGuid);
        Teacher GetTeacherByName(string Name);
        Address GetTeacherAdress(Teacher teacher);
        List<WorkingHoursOfWeek> GetMeetForWeek();
        void CreateWorkingForOneHour(WorkingForOneHour hour);


    }
}
