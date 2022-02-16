using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidersGo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace bidersGo.Application.Interfaces.Context
{
    public interface IApplicationDbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonDetail> LessonDetails { get; set; }
        public DbSet<Meet> Meets { get; set; }
        public DbSet<Moderator> Moderators { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<WorkingHoursOfWeek> WorkingHoursOfWeeks { get; set; }
    }
}
