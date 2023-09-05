namespace Memorabilia.Repository;

public class MemorabiliaContext : DbContext, IMemorabiliaContext
{
    public DbSet<Entity.CollectionMemorabilia> CollectionMemorabilia { get; set; }

    public DbSet<Entity.Memorabilia> Memorabilia { get; set; }

    public DbSet<Entity.MemorabiliaForSale> MemorabiliaForSale { get; set; }

    public DbSet<Entity.MemorabiliaTransaction> MemorabiliaTransaction { get; set; }

    public DbSet<Entity.MemorabiliaTransactionSale> MemorabiliaTransactionSale { get; set; }

    public DbSet<Entity.MemorabiliaTransactionTrade> MemorabiliaTransactionTrade { get; set; }

    public MemorabiliaContext(DbContextOptions<MemorabiliaContext> options) 
        : base(options) { }        

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entity.Acquisition>()
                    .Property(x => x.Cost)
                    .HasPrecision(12, 2);     
        
        modelBuilder.Entity<Entity.Autograph>()
                    .Property(x => x.EstimatedValue)
                    .HasPrecision(12, 2);

        modelBuilder.Entity<Entity.AutographAuthentication>();
        modelBuilder.Entity<Entity.AutographImage>();
        modelBuilder.Entity<Entity.AutographSpot>();
        modelBuilder.Entity<Entity.Collection>();
        modelBuilder.Entity<Entity.CollectionMemorabilia>();
        modelBuilder.Entity<Entity.Inscription>();

        modelBuilder.Entity<Entity.Memorabilia>()
                    .Property(x => x.EstimatedValue)
                    .HasPrecision(12, 2);

        modelBuilder.Entity<Entity.MemorabiliaAcquisition>();
        modelBuilder.Entity<Entity.MemorabiliaBammer>();
        modelBuilder.Entity<Entity.MemorabiliaBaseball>();
        modelBuilder.Entity<Entity.MemorabiliaBasketball>();
        modelBuilder.Entity<Entity.MemorabiliaBat>();
        modelBuilder.Entity<Entity.MemorabiliaBobblehead>();
        modelBuilder.Entity<Entity.MemorabiliaBook>();
        modelBuilder.Entity<Entity.MemorabiliaBrand>();
        modelBuilder.Entity<Entity.MemorabiliaCard>();
        modelBuilder.Entity<Entity.MemorabiliaCereal>();
        modelBuilder.Entity<Entity.MemorabiliaCommissioner>();
        modelBuilder.Entity<Entity.MemorabiliaFigure>();
        modelBuilder.Entity<Entity.MemorabiliaFootball>();
        modelBuilder.Entity<Entity.MemorabiliaForSale>();
        modelBuilder.Entity<Entity.MemorabiliaGame>();
        modelBuilder.Entity<Entity.MemorabiliaGlove>();
        modelBuilder.Entity<Entity.MemorabiliaHelmet>();
        modelBuilder.Entity<Entity.MemorabiliaImage>();
        modelBuilder.Entity<Entity.MemorabiliaJersey>();
        modelBuilder.Entity<Entity.MemorabiliaJerseyNumber>();
        modelBuilder.Entity<Entity.MemorabiliaLevelType>();
        modelBuilder.Entity<Entity.MemorabiliaMagazine>();
        modelBuilder.Entity<Entity.MemorabiliaPerson>();
        modelBuilder.Entity<Entity.MemorabiliaPicture>();
        modelBuilder.Entity<Entity.MemorabiliaSize>();
        modelBuilder.Entity<Entity.MemorabiliaSport>();
        modelBuilder.Entity<Entity.MemorabiliaTeam>();
        modelBuilder.Entity<Entity.MemorabiliaTransaction>();
        modelBuilder.Entity<Entity.MemorabiliaTransactionSale>();
        modelBuilder.Entity<Entity.MemorabiliaTransactionTrade>();
        modelBuilder.Entity<Entity.Personalization>();          
        modelBuilder.Entity<Entity.Project>();          
        modelBuilder.Entity<Entity.ProjectBaseball>();          
        modelBuilder.Entity<Entity.ProjectCard>();          
        modelBuilder.Entity<Entity.ProjectHallOfFame>();          
        modelBuilder.Entity<Entity.ProjectHelmet>();          
        modelBuilder.Entity<Entity.ProjectItem>();          
        modelBuilder.Entity<Entity.ProjectMemorabiliaTeam>();         
        modelBuilder.Entity<Entity.ProjectPerson>();         
        modelBuilder.Entity<Entity.ProjectTeam>();         
        modelBuilder.Entity<Entity.ProjectWorldSeries>();         
        modelBuilder.Entity<Entity.ThroughTheMail>();         
        modelBuilder.Entity<Entity.ThroughTheMailMemorabilia>();  
    }
}
