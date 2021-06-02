using EZLabor.API.Accounts.Domain.Model;
using EZLabor.API.Accounts.Extensions;
using EZLabor.API.SocialMedia.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Domain.Persistence.Contexts
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Publication> Publications { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Publication Entity
            builder.Entity<Publication>().ToTable("Publications");
            //Contraints
            builder.Entity<Publication>().HasKey(p => p.Id);
            builder.Entity<Publication>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Publication>().Property(p => p.Name).IsRequired();
            builder.Entity<Publication>().Property(p => p.UploadAt).IsRequired();
            builder.Entity<Publication>().Property(p => p.VideoUrl).IsRequired();

            // Relationships
            builder.Entity<Publication>()
                .HasMany(p => p.Comments)
                .WithOne(p => p.Publication)
                .HasForeignKey(p => p.PublicationId);

            // Seed Data
            builder.Entity<Publication>().HasData
                (
                    new Publication { Id = 100, Name = "Graphic Designer Wanted", UploadAt = "2018-12-19 09:26:03.478039", VideoUrl = "www.youtube.com/tyr456", UserId = 102 }
                );

            //Comment Entity
            builder.Entity<Comment>().ToTable("Comments");
            //Contraints
            builder.Entity<Comment>().HasKey(p => p.Id);
            builder.Entity<Comment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Comment>().Property(p => p.Content).IsRequired();

            // Seed Data
            builder.Entity<Comment>().HasData
                (
                new Comment { Id = 45, PublicationId= 100, Content = "Raddaraddaradda"}                
                );

            //Notification Entity
            builder.Entity<Notification>().ToTable("Notifications");
            //Contraints
            builder.Entity<Notification>().HasKey(p => p.Id);
            builder.Entity<Notification>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Notification>().Property(p => p.Description).IsRequired();
            builder.Entity<Notification>().Property(p => p.NotificationTime).IsRequired();

            // Seed Data
            builder.Entity<Notification>().HasData
                (
                new Notification { Id = 53, Description = "Has añadido a la planilla laboral", NotificationTime = 14:05, UserId = 409 }
                );

            //User Entity
            builder.Entity<User>().ToTable("Users");
            //Contraints
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.UserName).IsRequired();
            builder.Entity<User>().Property(p => p.Email).IsRequired();
            builder.Entity<User>().Property(p => p.Password).IsRequired();

            // Relationships
            builder.Entity<User>()
                .HasMany(p => p.Comments)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            builder.Entity<User>()
                .HasMany(p => p.Publications)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            builder.Entity<User>()
                .HasMany(p => p.Notifications)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);


            // Apply Naming Convention
            builder.ApplySnakeCaseNamingConvention();
        }

    }
}
