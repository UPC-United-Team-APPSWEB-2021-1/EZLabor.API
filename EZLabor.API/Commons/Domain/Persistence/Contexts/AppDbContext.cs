﻿using EZLabor.API.Domain.Models;
using EZLabor.API.Extensions;
using EZLabor.API.Hiring.Domain.Model;
using EZLabor.API.Messaging.Domain.Model;
using EZLabor.API.SocialMedia.Domain.Model;
using EZLabor.API.Subscription.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Accounts System
        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Proposal> Proposals { get; set; }

        //Hiring System
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Postulation> Postulations { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Solution> Solutions { get; set; }

        //SocialMedia System
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Comment> Comments { get; set; }
        //public DbSet<Follow> Follows { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }

        //Subscription System
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }

        //Messaging System
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //
            //Accounts System-------------------------------------------------------------
            //

            ///Freelancer Entity
            builder.Entity<Freelancer>().ToTable("Freelancer");
            //Contraints
            builder.Entity<Freelancer>().HasKey(p => p.Id);
            builder.Entity<Freelancer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Freelancer>().Property(p => p.UserName).IsRequired().HasMaxLength(30);
            builder.Entity<Freelancer>().Property(p => p.Email).IsRequired();
            builder.Entity<Freelancer>().Property(p => p.Rating);
            builder.Entity<Freelancer>().Property(p => p.Specially);

            //Seed Data
            builder.Entity<Freelancer>().HasData
                (
                    new Freelancer
                    {
                        Id = 100,
                        UserName = "Jhon Andrew",
                        Email = "address100@mail.com",
                        Rating = 8,
                        Specially = "Graphic Design"
                    },
                    new Freelancer
                    {
                        Id = 101,
                        UserName = "Steve Jobs",
                        Email = "address101@mail.com",
                        Rating = 9,
                        Specially = "Software Engineering"
                    }
                );
            

            ///Employer Entity
            builder.Entity<Employer>().ToTable("Employer");
            //Contraints
            builder.Entity<Employer>().HasKey(p => p.Id);
            builder.Entity<Employer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Employer>().Property(p => p.UserName).IsRequired().HasMaxLength(30);
            builder.Entity<Employer>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Employer>().Property(p => p.Email).IsRequired();
            builder.Entity<Employer>().Property(p => p.CorporativeEmail);
            builder.Entity<Employer>().Property(p => p.Website);

            
            //Seed Data
            builder.Entity<Employer>().HasData
                (
                    new Employer
                    {
                        Id = 200,
                        Name = "Geronimo Bustamante Chafloque",
                        UserName = "Gino Bustamante",
                        Email = "address200@mail.com",
                        CorporativeEmail = "address200@acme.com",
                        Website = "acme.com"
                    },
                    new Employer
                    {
                        Id = 201,
                        Name = "Maria Fernandez Cabrejo",
                        UserName = "Maria Fernadez",
                        Email = "address201@mail.com",
                        CorporativeEmail = "address201@microsoft.com",
                        Website = "microsoft.com"
                    }
                );


            ///Skill Entity
            builder.Entity<Skill>().ToTable("Skill");
            //Contraints
            builder.Entity<Skill>().HasKey(p => p.Id);
            builder.Entity<Skill>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Skill>().Property(p => p.TechnologyName).IsRequired().HasMaxLength(50);
            builder.Entity<Skill>().Property(p => p.CertificateUrl);
            builder.Entity<Skill>()
                .HasOne(pt => pt.Freelancer)
                .WithMany(pt => pt.Skills)
                .HasForeignKey(pt => pt.FreelancerId);

            //Seed Data
            builder.Entity<Skill>().HasData
                (
                    new Skill
                    {
                        Id = 300,
                        TechnologyName = "Advanced skill in web applications",
                    },
                    new Skill
                    {
                        Id = 301,
                        TechnologyName = "Advanced skill in photoshop",
                    }
                );
            

            ///Proposal Entity
            builder.Entity<Proposal>().ToTable("Proposal");
            //Contraints
            builder.Entity<Proposal>().HasKey(p => p.Id);
            builder.Entity<Proposal>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Proposal>().Property(p => p.Description).IsRequired();
            builder.Entity<Proposal>().Property(p => p.PaymentAmount).IsRequired();
            builder.Entity<Proposal>().Property(p => p.MoneyType).IsRequired();
            builder.Entity<Proposal>().Property(p => p.ProposalState).IsRequired();
            //Relationships
            builder.Entity<Proposal>()
                .HasOne(pt => pt.Freelancer)
                .WithMany(pt => pt.Proposals)
                .HasForeignKey(pt => pt.FreelancerId);
            builder.Entity<Proposal>()
                .HasOne(pt => pt.Employer)
                .WithMany(pt => pt.Proposals)
                .HasForeignKey(pt => pt.EmployerId);
            
            //Seed Data
            builder.Entity<Proposal>().HasData
                (
                    new Proposal
                    {
                        Id = 400,
                        Description = "Elaborate company logo",
                        PaymentAmount = 25.00,
                        MoneyType = EMoneyType.USD,
                        ProposalState = EProposalState.IP,
                        FreelancerId = 100,
                        EmployerId = 200
                    },
                    new Proposal
                    {
                        Id = 401,
                        Description = "API Development",
                        PaymentAmount = 125.00,
                        MoneyType = EMoneyType.EUR,
                        ProposalState = EProposalState.F,
                        FreelancerId = 101,
                        EmployerId = 200
                    },
                    new Proposal
                    {
                        Id = 402,
                        Description = "API Development",
                        PaymentAmount = 425.00,
                        MoneyType = EMoneyType.PEN,
                        ProposalState = EProposalState.C,
                        FreelancerId = 101,
                        EmployerId = 201
                    },
                    new Proposal
                    {
                        Id = 403,
                        Description = "Elaborate company logo",
                        PaymentAmount = 128.00,
                        MoneyType = EMoneyType.PEN,
                        ProposalState = EProposalState.IP,
                        FreelancerId = 100,
                        EmployerId = 201
                    }
                );


            //
            //Hiring System-------------------------------------------------------------
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
                        Id = 100,
                        Description = "qwdd",
                        Duration = 1
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

            //
            //SocialMedia System-------------------------------------------------------------
            //


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
                    new Publication { Id = 100, Name = "Graphic Designer Wanted", UploadAt = DateTime.ParseExact("19/12/2018", "dd/MM/yyyy", null), VideoUrl = "www.youtube.com/tyr456", FreelancerId = 100 }
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
                new Comment { Id = 45, PublicationId = 100, Content = "Raddaraddaradda" }
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
                new Notification { Id = 53, Description = "Has añadido a la planilla laboral", NotificationTime = DateTime.Parse("14:05"), FreelancerId = 100 }
                );
            
            
            
            // Relationships

            builder.Entity<Freelancer>()
                .HasMany(p => p.Comments)
                .WithOne(p => p.Freelancer)
                .HasForeignKey(p => p.FreelancerId);

            builder.Entity<Freelancer>()
                .HasMany(p => p.Publications)
                .WithOne(p => p.Freelancer)
                .HasForeignKey(p => p.FreelancerId);

            builder.Entity<Freelancer>()
                .HasMany(p => p.Notifications)
                .WithOne(p => p.Freelancer)
                .HasForeignKey(p => p.FreelancerId);

            builder.Entity<Employer>()
                .HasMany(p => p.Comments)
                .WithOne(p => p.Employer)
                .HasForeignKey(p => p.EmployerId);

            builder.Entity<Employer>()
                .HasMany(p => p.Publications)
                .WithOne(p => p.Employer)
                .HasForeignKey(p => p.EmployerId);

            builder.Entity<Employer>()
                .HasMany(p => p.Notifications)
                .WithOne(p => p.Employer)
                .HasForeignKey(p => p.EmployerId);

            //
            //Suscription System-------------------------------------------------------------
            //

            //SubscriptionPlan Entity
            builder.Entity<SubscriptionPlan>().ToTable("SubscriptionPlan");
            //Contraints
            builder.Entity<SubscriptionPlan>().HasKey(p => p.Id);
            builder.Entity<SubscriptionPlan>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<SubscriptionPlan>().Property(p => p.Name).IsRequired().HasMaxLength(30);



            //Seed Data
            builder.Entity<SubscriptionPlan>().HasData
                (
                    new SubscriptionPlan
                    {
                        Id = 601,
                        Name = "Premium"
                    },
                    new SubscriptionPlan
                    {
                        Id = 602,
                        Name = "No Premium"
                    }
                );

            builder.Entity<Freelancer>()
                .HasOne(p => p.SubscriptionPlan)
                .WithMany(p => p.Freelancers)
                .HasForeignKey(p => p.SubscriptionPlanId);

            //
            //Messaging System-------------------------------------------------------------
            //

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
