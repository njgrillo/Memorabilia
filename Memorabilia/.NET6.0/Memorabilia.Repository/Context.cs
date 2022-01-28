using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;

namespace Memorabilia.Repository
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Domain.Entities.Account>().Property(x => x.Balance).HasPrecision(15, 2);
            //modelBuilder.Entity<Domain.Entities.Bill>().Property(x => x.Amount).HasPrecision(15, 2);
            //modelBuilder.Entity<Domain.Entities.Fund>().Property(x => x.Amount).HasPrecision(15, 2);
            //modelBuilder.Entity<Domain.Entities.Goal>().Property(x => x.Amount).HasPrecision(15, 2);
            //modelBuilder.Entity<Domain.Entities.Income>();
            //modelBuilder.Entity<Domain.Entities.Mortgage>().Property(x => x.AssessedValue).HasPrecision(15, 2);
            //modelBuilder.Entity<Domain.Entities.Mortgage>().Property(x => x.InterestRate).HasPrecision(5, 3);
            //modelBuilder.Entity<Domain.Entities.Mortgage>().Property(x => x.MonthlyPayment).HasPrecision(15, 2);
            //modelBuilder.Entity<Domain.Entities.Mortgage>().Property(x => x.OriginalLoanAmount).HasPrecision(15, 2);
            //modelBuilder.Entity<Domain.Entities.Mortgage>().Property(x => x.YearlyFloodInsurance).HasPrecision(15, 2);
            //modelBuilder.Entity<Domain.Entities.Mortgage>().Property(x => x.YearlyInsurance).HasPrecision(15, 2);
            //modelBuilder.Entity<Domain.Entities.Mortgage>().Property(x => x.YearlyTaxPayment).HasPrecision(15, 2);
            //modelBuilder.Entity<Domain.Entities.Retirement>().Property(x => x.EstimatedInterestRate).HasPrecision(4, 2);
            //modelBuilder.Entity<Domain.Entities.Retirement>().Property(x => x.ContributionRate).HasPrecision(5, 2);
            //modelBuilder.Entity<Domain.Entities.Retirement>().Property(x => x.MatchRate).HasPrecision(5, 2);
            //modelBuilder.Entity<Domain.Entities.Retirement>().Property(x => x.MaximumMatch).HasPrecision(5, 2);
            //modelBuilder.Entity<Domain.Entities.Retirement>().Property(x => x.MonthlyContributionAmount).HasPrecision(8, 2);
            //modelBuilder.Entity<Domain.Entities.Plan>();
            //modelBuilder.Entity<Domain.Entities.PlanAccount>().Property(x => x.Amount).HasPrecision(9, 2);
            modelBuilder.Entity<Domain.Entities.User>();
        }

        //protected virtual void SetAuditProperties()
        //{
        //    ChangeTracker.Entries<IAuditableEntity>().Where<DbEntityEntry<IAuditableEntity>>((Func < DbEntityEntry<IAuditableEntity>, bool)(e => e.State == EntityState.Added)).ForEach<DbEntityEntry<IAuditableEntity>>((Action<DbEntityEntry<IAuditableEntity>>)(e =>
        //     {
        //         e.Entity.CreateDate = DateTimeProvider.UtcNow;
        //         e.Entity.UserId = 0;
        //     }));
        //}
    }
}
