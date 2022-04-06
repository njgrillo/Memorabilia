using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Memorabilia.Repository
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acquisition>().Property(x => x.Cost).HasPrecision(12, 2);          
            modelBuilder.Entity<Autograph>().Property(x => x.EstimatedValue).HasPrecision(12, 2);
            modelBuilder.Entity<AutographAuthentication>();
            modelBuilder.Entity<AutographImage>();
            modelBuilder.Entity<AutographSpot>();
            modelBuilder.Entity<AutographThroughTheMail>();
            modelBuilder.Entity<Inscription>();
            modelBuilder.Entity<Domain.Entities.Memorabilia>().Property(x => x.EstimatedValue).HasPrecision(12, 2);
            modelBuilder.Entity<MemorabiliaAcquisition>();
            modelBuilder.Entity<MemorabiliaBaseball>();
            modelBuilder.Entity<MemorabiliaBasketball>();
            modelBuilder.Entity<MemorabiliaBat>();
            modelBuilder.Entity<MemorabiliaBook>();
            modelBuilder.Entity<MemorabiliaBrand>();
            modelBuilder.Entity<MemorabiliaCanvas>();
            modelBuilder.Entity<MemorabiliaCard>();
            modelBuilder.Entity<MemorabiliaCommissioner>();
            modelBuilder.Entity<MemorabiliaFigure>();
            modelBuilder.Entity<MemorabiliaFootball>();
            modelBuilder.Entity<MemorabiliaGame>();
            modelBuilder.Entity<MemorabiliaHelmet>();
            modelBuilder.Entity<MemorabiliaImage>();
            modelBuilder.Entity<MemorabiliaJersey>();
            modelBuilder.Entity<MemorabiliaLevelType>();
            modelBuilder.Entity<MemorabiliaLithograph>();
            modelBuilder.Entity<MemorabiliaMagazine>();
            modelBuilder.Entity<MemorabiliaOrientation>();
            modelBuilder.Entity<MemorabiliaPerson>();
            modelBuilder.Entity<MemorabiliaPhoto>();
            modelBuilder.Entity<MemorabiliaSize>();
            modelBuilder.Entity<MemorabiliaSport>();
            modelBuilder.Entity<MemorabiliaTeam>();
            modelBuilder.Entity<Personalization>();          
        }
    }
}
