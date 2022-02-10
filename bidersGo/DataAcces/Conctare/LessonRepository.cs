using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.DataAcces.Abstract;
using bidersGo.Entities;
using Microsoft.EntityFrameworkCore;

namespace bidersGo.DataAcces.Conctare
{
    public class LessonRepository : GenericRepository<Lesson>, ILessonRepository
    {
        private readonly BidersGoContext _context;
        public LessonRepository(BidersGoContext context):base(context)
        {
            _context = context;
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
    }
}
