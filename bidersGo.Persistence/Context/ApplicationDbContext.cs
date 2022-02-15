﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidersGo.Application.Interfaces.Context;
using Microsoft.EntityFrameworkCore;
using bidersGo.Domain.Entities;
using bidersGo.Persistence.Context.Configuration;

namespace bidersGo.Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
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
        public DbSet<WorkingHoursOfWeek> WorkingHoursOfWeeks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //asagıdaki methodların calısması için bu satırı yazmaka şart..

            modelBuilder.Entity<LessonDetail>()
                .HasOne(x => x.Lesson)
                .WithMany(x => x.LessonDetails)
                .HasForeignKey(x => x.LessonId);

            modelBuilder.Entity<Meet>()
                .HasOne(x => x.Student)
                .WithMany(x => x.Meets)
                .HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<Meet>()
                .HasOne(x => x.Teacher)
                .WithMany(x => x.Meets)
                .HasForeignKey(x => x.TeacherId);

            modelBuilder.Entity<Meet>()
                .HasOne(x => x.Lesson)
                .WithMany(x => x.Meets)
                .HasForeignKey(x => x.LessonId);

            modelBuilder.Entity<SubscriptionType>()
                .HasOne(x => x.Subscription)
                .WithMany(x => x.SubscriptionTypes)
                .HasForeignKey(x => x.SubscriptionId);

            modelBuilder.Entity<Student>()
                .HasOne(x => x.Subscription)
                .WithMany(x => x.Student)
                .HasForeignKey(x => x.SubscriptionId);

            modelBuilder.Entity<WorkingHoursOfWeek>()
                .HasOne(x => x.Teacher)
                .WithMany(x => x.WorkingHoursOfWeek)
                .HasForeignKey(x => x.TeacherId);

            modelBuilder.ApplyConfiguration(new LessonConfiguration());


        }
    }
