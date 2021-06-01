using EZLabor.API.Domain.Models;
using EZLabor.API.Extensions;
using EZLabor.API.Hiring.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Domain.Persistence.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //Hiring System
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Postulation> Postulations { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Solution> Solutions { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Hiring System
            //


            //Requirement Entity
            builder.Entity<Requirement>().ToTable("Requirements");
            //Contraints
            builder.Entity<Requirement>().HasKey(p => p.Id);
            builder.Entity<Requirement>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Requirement>().Property(p => p.Name).IsRequired();
            builder.Entity<Requirement>().Property(p => p.SkillLevel).IsRequired();

            //Relationships
            builder.Entity<Requirement>()
                .HasOne(pt => pt.Offer)
                .WithMany(pt => pt.Requirements)
                .HasForeignKey(pt => pt.OfferId);

            //Seed Data
            builder.Entity<Requirement>().HasData
                (
                    new Requirement
                    {
                        Id = 400,
                        Name = "HTML",
                        SkillLevel = 3,
                        OfferId = 10
                    },
                    new Requirement
                    {
                        Id = 500,
                        Name = "CSS",
                        SkillLevel = 3,
                        OfferId = 20
                    },
                    new Requirement
                    {
                        Id = 600,
                        Name = "JS",
                        SkillLevel = 3,
                        OfferId = 30
                    }
                );



            //Offer Entity
            builder.Entity<Offer>().ToTable("Offers");
            //Contraints
            builder.Entity<Offer>().HasKey(p => p.Id);
            builder.Entity<Offer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Offer>().Property(p => p.Payment).IsRequired();
            builder.Entity<Offer>().Property(p => p.CreatedAt).IsRequired();
            builder.Entity<Offer>().Property(p => p.State).IsRequired();
            builder.Entity<Offer>().Property(p => p.Title).IsRequired();

            //Relationships
            builder.Entity<Offer>()
                .HasOne(pt => pt.Employer)
                .WithMany(pt => pt.Offers)
                .HasForeignKey(pt => pt.EmployerId);

            //Seed Data
            builder.Entity<Offer>().HasData
                (
                    new Offer
                    {
                        Id = 400,
                        EmployerId = 10,
                        Payment = 300,
                        State = "Pendiente",
                        Title = "Diseño web",
                        Duration = 3
                    }
                );


            //Offer Postulation
            builder.Entity<Postulation>().ToTable("Postulations");
            //Contraints
            builder.Entity<Postulation>().HasKey(p => p.Id);
            builder.Entity<Postulation>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Postulation>().Property(p => p.Description).IsRequired();
            builder.Entity<Postulation>().Property(p => p.Payment).IsRequired();
            builder.Entity<Postulation>().Property(p => p.CreatedAt);
            builder.Entity<Postulation>().Property(p => p.State).IsRequired();

            //Relationships
            builder.Entity<Postulation>()
                .HasOne(pt => pt.Offer)
                .WithMany(pt => pt.Postulations)
                .HasForeignKey(pt => pt.OfferId);

            builder.Entity<Postulation>()
                .HasOne(pt => pt.Freelancer)
                .WithMany(pt => pt.Postulations)
                .HasForeignKey(pt => pt.FreelancerId);

            





            //Seed Data
            builder.Entity<Postulation>().HasData
                (
                    new Postulation
                    {
                        Id = 400,
                        Description = "dsadas",
                        Payment = 300,
                        State = "Pendiente"
                    }
                );


            //Offer Meeting
            builder.Entity<Meeting>().ToTable("Meetings");
            //Contraints
            builder.Entity<Meeting>().HasKey(p => p.Id);
            builder.Entity<Meeting>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Meeting>().Property(p => p.Description).IsRequired();
            builder.Entity<Meeting>().Property(p => p.CreatedAt);
            builder.Entity<Meeting>().Property(p => p.Duration).IsRequired();

            //Relationships
            builder.Entity<Meeting>()
                .HasOne(pt => pt.Postulation)
                .WithMany(pt => pt.Meetings)
                .HasForeignKey(pt => pt.PostulationId);

            //Seed Data
            builder.Entity<Meeting>().HasData
                (
                    new Meeting
                    {
                        Id=100,
                        Description="qwdd",
                        Duration=1
                    }
                );


            //Offer Solution
            builder.Entity<Solution>().ToTable("Solutions");
            //Contraints
            builder.Entity<Solution>().HasKey(p => p.Id);
            builder.Entity<Solution>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Solution>().Property(p => p.State).IsRequired();
            builder.Entity<Solution>().Property(p => p.CreatedAt);

            //Relationships
            
            builder.Entity<Solution>()
                .HasOne(pt => pt.Postulation)
                .WithMany(pt => pt.Solutions)
                .HasForeignKey(pt => pt.PostulationId);
            
            //Seed Data
            builder.Entity<Solution>().HasData
                (
                    new Solution
                    {
                        Id = 100,
                        State = "Completado",


                    }
                );

            // Apply Naming Convention
            builder.ApplySnakeCaseNamingConvention();
        }

    }
}
