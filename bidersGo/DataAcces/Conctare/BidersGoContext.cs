using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Entities;
using Microsoft.EntityFrameworkCore;

namespace bidersGo.DataAcces.Conctare
{
    public class BidersGoContext :DbContext
    {
        public BidersGoContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonDetail> LessonDetails { get; set; }
        public DbSet<Meet> Meets { get; set; }
        public DbSet<Moderator> Moderators { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LessonDetail>()
                .HasOne<Lesson>(x => x.Lesson)
                .WithMany(x => x.LessonDetails)
                .HasForeignKey(x => x.LessonId);
        }






    }
}
