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
        void CreateWorkingForWeek(WorkingHoursOfWeek hour);
        void CreateWorkingWeekAddToTeacher(Guid teacherGuid, WorkingHoursOfWeek hours);
        WorkingHoursOfWeek GetWorkingTable(Guid id);
        WorkingHoursOfWeek GetByTeacherId(Guid id);
        Teacher GetTeacherByUserId(string id);
        Teacher GetTeacherByWorkingTableId(Guid id);

    }
}
