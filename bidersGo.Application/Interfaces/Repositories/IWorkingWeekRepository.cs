using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidersGo.Domain.Entities;

namespace bidersGo.Application.Interfaces.Repositories
{
    public interface IWorkingWeekRepository : IRepository<WorkingHoursOfWeek>
    {
        WorkingHoursOfWeek WorkingHoursOfWeek(Guid Id);

        WorkingHoursOfWeek HocaTablosu(Guid HocaIdsi);

        void setApmoinment(WorkingForOneHour entityForOneHour);

        void UpdateAppointment(WorkingForOneHour entityForOneHour );

        void DeleteAppointment(Guid id);
    }
}
