using EZLabor.API.Accounts.Domain.Model;
using EZLabor.API.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Domain.Persistence.Contexts
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Proposal> Proposals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ///Freelancer Entity
            builder.Entity<Freelancer>().ToTable("Freelancer");
            //Contraints
            builder.Entity<Freelancer>().HasKey(p => p.Id);
            builder.Entity<Freelancer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Freelancer>().Property(p => p.UserName).IsRequired().HasMaxLength(30);
            builder.Entity<Freelancer>().Property(p => p.Email).IsRequired();
            builder.Entity<Freelancer>().Property(p => p.Password).IsRequired();
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
                        Password = "password",
                        Rating = 8,
                        Specially = "Graphic Design"
                    },
                    new Freelancer
                    {
                        Id = 101,
                        UserName = "Steve Jobs",
                        Email = "address101@mail.com",
                        Password = "password",
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
            builder.Entity<Employer>().Property(p => p.Password).IsRequired();
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
                        Password = "password",
                        CorporativeEmail = "address200@acme.com",
                        Website = "acme.com"
                    },
                    new Employer
                    {
                        Id = 201,
                        Name = "Maria Fernandez Cabrejo",
                        UserName = "Maria Fernadez",
                        Email = "address201@mail.com",
                        Password = "password",
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


            
            

            // Apply Naming Convention
            builder.ApplySnakeCaseNamingConvention();
        }
    }
}
