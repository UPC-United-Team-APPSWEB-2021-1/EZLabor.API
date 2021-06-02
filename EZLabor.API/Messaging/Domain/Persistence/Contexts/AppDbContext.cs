using EZLabor.API.Extensions;
using EZLabor.API.Messaging.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Messaging.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            ///Message Entity
            builder.Entity<Message>().ToTable("Message");
            //Contraints
            builder.Entity<Message>().HasKey(p => p.Id);
            builder.Entity<Message>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Message>().Property(p => p.Content).IsRequired();

            //Relationships
            builder.Entity<Message>()
                .HasOne(pt => pt.Freelancer)
                .WithMany(pt => pt.Messages)
                .HasForeignKey(pt => pt.FreelancerId);
            builder.Entity<Message>()
                .HasOne(pt => pt.Employer)
                .WithMany(pt => pt.Messages)
                .HasForeignKey(pt => pt.EmployerId);


            //Seed Data
            builder.Entity<Message>().HasData
                (
                    new Message
                    {
                        Id = 501,
                        Content = "Hello!",
                        FreelancerId = 100,
                        EmployerId = 200
                    },
                    new Message
                    {
                        Id = 502,
                        Content = "Hi there!",
                        FreelancerId = 100,
                        EmployerId = 200
                    },
                    new Message
                    {
                        Id = 503,
                        Content = "How are you?",
                        FreelancerId = 100,
                        EmployerId = 200
                    },
                    new Message
                    {
                        Id = 504,
                        Content = "Good and you?",
                        FreelancerId = 100,
                        EmployerId = 200
                    }
                );

            // Apply Naming Convention
            builder.ApplySnakeCaseNamingConvention();
        }
    }
}
