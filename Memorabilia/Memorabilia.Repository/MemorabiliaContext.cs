using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository;

public class MemorabiliaContext : DbContext, IMemorabiliaContext
{
    public DbSet<Domain.Entities.Memorabilia> Memorabilia { get; set; }

    public MemorabiliaContext(DbContextOptions<MemorabiliaContext> options) : base(options) { }        

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
        modelBuilder.Entity<MemorabiliaBammer>();
        modelBuilder.Entity<MemorabiliaBaseball>();
        modelBuilder.Entity<MemorabiliaBasketball>();
        modelBuilder.Entity<MemorabiliaBat>();
        modelBuilder.Entity<MemorabiliaBobblehead>();
        modelBuilder.Entity<MemorabiliaBook>();
        modelBuilder.Entity<MemorabiliaBrand>();
        modelBuilder.Entity<MemorabiliaCard>();
        modelBuilder.Entity<MemorabiliaCereal>();
        modelBuilder.Entity<MemorabiliaCommissioner>();
        modelBuilder.Entity<MemorabiliaFigure>();
        modelBuilder.Entity<MemorabiliaFootball>();
        modelBuilder.Entity<MemorabiliaGame>();
        modelBuilder.Entity<MemorabiliaGlove>();
        modelBuilder.Entity<MemorabiliaHelmet>();
        modelBuilder.Entity<MemorabiliaImage>();
        modelBuilder.Entity<MemorabiliaJersey>();
        modelBuilder.Entity<MemorabiliaJerseyNumber>();
        modelBuilder.Entity<MemorabiliaLevelType>();
        modelBuilder.Entity<MemorabiliaMagazine>();
        modelBuilder.Entity<MemorabiliaPerson>();
        modelBuilder.Entity<MemorabiliaPicture>();
        modelBuilder.Entity<MemorabiliaSize>();
        modelBuilder.Entity<MemorabiliaSport>();
        modelBuilder.Entity<MemorabiliaTeam>();
        modelBuilder.Entity<Personalization>();          
        modelBuilder.Entity<Project>();          
        modelBuilder.Entity<ProjectPerson>();         
    }
}
