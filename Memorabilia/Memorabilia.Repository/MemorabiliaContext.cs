namespace Memorabilia.Repository;

public class MemorabiliaContext(DbContextOptions<MemorabiliaContext> options)
    : DbContext(options), IMemorabiliaContext
{
    public DbSet<Address> Address { get; set; }

    public DbSet<CollectionMemorabilia> CollectionMemorabilia { get; set; }

    public DbSet<Entity.Memorabilia> Memorabilia { get; set; }

    public DbSet<MemorabiliaForSale> MemorabiliaForSale { get; set; }

    public DbSet<MemorabiliaTransaction> MemorabiliaTransaction { get; set; }

    public DbSet<MemorabiliaTransactionSale> MemorabiliaTransactionSale { get; set; }

    public DbSet<MemorabiliaTransactionTrade> MemorabiliaTransactionTrade { get; set; }

    public DbSet<PrivateSigning> PrivateSigning { get; set; }

    public DbSet<SignatureIdentification> SignatureIdentification { get; set; }

    public DbSet<SignatureReview> SignatureReview { get; set; }

    public DbSet<ThroughTheMail> ThroughTheMail { get; set; }

    public DbSet<ThroughTheMailMemorabilia> ThroughTheMailMemorabilia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acquisition>(); 
        modelBuilder.Entity<Autograph>();
        modelBuilder.Entity<AutographAuthentication>();
        modelBuilder.Entity<AutographImage>();
        modelBuilder.Entity<AutographSpot>();       
        modelBuilder.Entity<Collection>();
        modelBuilder.Entity<CollectionMemorabilia>();
        modelBuilder.Entity<Inscription>();
        modelBuilder.Entity<Entity.Memorabilia>();
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
        modelBuilder.Entity<MemorabiliaForSale>();
        modelBuilder.Entity<MemorabiliaForSale>();
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
        modelBuilder.Entity<MemorabiliaTransaction>();
        modelBuilder.Entity<MemorabiliaTransactionSale>();
        modelBuilder.Entity<MemorabiliaTransactionTrade>();
        modelBuilder.Entity<Offer>();
        modelBuilder.Entity<Personalization>();
        modelBuilder.Entity<PrivateSigning>();
        modelBuilder.Entity<PrivateSigningAuthenticationCompany>(); 
        modelBuilder.Entity<PrivateSigningCustomItemGroup>();
        modelBuilder.Entity<PrivateSigningCustomItemTypeGroup>();
        modelBuilder.Entity<PrivateSigningCustomItemTypeGroupDetail>(); 
        modelBuilder.Entity<PrivateSigningItemTypeGroup>();
        modelBuilder.Entity<PrivateSigningPerson>();
        modelBuilder.Entity<PrivateSigningPersonDetail>();
        modelBuilder.Entity<PrivateSigningPersonExcludeItemType>();
        modelBuilder.Entity<PrivateSigningPromoterProvidedItem>();
        modelBuilder.Entity<Project>();          
        modelBuilder.Entity<ProjectBaseball>();          
        modelBuilder.Entity<ProjectCard>();          
        modelBuilder.Entity<ProjectHallOfFame>();          
        modelBuilder.Entity<ProjectHelmet>();          
        modelBuilder.Entity<ProjectItem>();           
        modelBuilder.Entity<ProjectMemorabiliaTeam>();
        modelBuilder.Entity<ProjectPerson>();
        modelBuilder.Entity<ProjectTeam>();         
        modelBuilder.Entity<ProjectWorldSeries>();
        modelBuilder.Entity<ProposeTrade>();
        modelBuilder.Entity<ProposeTradeMemorabilia>();
        modelBuilder.Entity<SignatureIdentification>();
        modelBuilder.Entity<SignatureIdentificationImage>();
        modelBuilder.Entity<SignatureIdentificationPerson>();
        modelBuilder.Entity<SignatureReview>();
        modelBuilder.Entity<SignatureReviewImage>();
        modelBuilder.Entity<SignatureReviewUserResult>();
        modelBuilder.Entity<ThroughTheMail>();           
        modelBuilder.Entity<ThroughTheMailMemorabilia>();
    }
}
