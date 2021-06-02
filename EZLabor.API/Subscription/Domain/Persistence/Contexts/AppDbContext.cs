using EZLabor.API.Subscription.Domain.Model;

namespace EZLabor.API.Subscription.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            


            ///SubscriptionPlan Entity
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

            // Apply Naming Convention
            builder.ApplySnakeCaseNamingConvention();
        }
    }
}
