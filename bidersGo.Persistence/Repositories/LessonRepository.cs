using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Application.Interfaces.Repositories;
using bidersGo.Domain.Entities;
using bidersGo.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace bidersGo.Persistence.Repositories
{
    public class LessonRepository : GenericRepository<Lesson>, ILessonRepository
    {
        private readonly ApplicationDbContext _context;
        public LessonRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public List<Teacher> GetAllTeacherWithLesson()
        {
            return _context.Teachers.ToList();
        }

        public List<Lesson> GetLessonsAll()
        {
            return _context.Lessons.ToList();
        }

        public Lesson GetLessonWithDetails(string LessonName)
        {
            return _context.Lessons
                .Where(x => x.LessonName == LessonName)
                .Include(x => x.LessonDetails)
                //.ThenInclude(x => x.LessonId)
                .FirstOrDefault();
        }

        public List<Teacher> GetTeacherForOneLesson(Guid guid)
        {
            //return _context.Teachers
            //    .Include(x => x.Lesson)
            //    .ThenInclude(x => x.Id)
            //    .Where(x=>x.LessonId == guid)
            //    .ToList();

            return _context.Teachers.Where(x => x.LessonId == guid).ToList();
        }
    }
}
