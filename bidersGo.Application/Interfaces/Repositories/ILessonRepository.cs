using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Domain.Entities;

namespace bidersGo.Application.Interfaces.Repositories
{
    public interface ILessonRepository:IRepository<Lesson>
    {
        Lesson GetLessonWithDetails(string LessonName);
        List<Lesson> GetLessonsAll();

    }
}
