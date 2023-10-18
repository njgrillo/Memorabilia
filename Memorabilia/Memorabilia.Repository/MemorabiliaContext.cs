namespace Memorabilia.Repository;

public class MemorabiliaContext : DbContext, IMemorabiliaContext
{
    public DbSet<CollectionMemorabilia> CollectionMemorabilia { get; set; }

    public DbSet<Entity.Memorabilia> Memorabilia { get; set; }

    public DbSet<MemorabiliaForSale> MemorabiliaForSale { get; set; }

    public DbSet<MemorabiliaTransaction> MemorabiliaTransaction { get; set; }

    public DbSet<MemorabiliaTransactionSale> MemorabiliaTransactionSale { get; set; }

    public DbSet<MemorabiliaTransactionTrade> MemorabiliaTransactionTrade { get; set; }

    public DbSet<PrivateSigning> PrivateSigning { get; set; }

    public DbSet<SignatureIdentification> SignatureIdentification { get; set; }

    public DbSet<SignatureReview> SignatureReview { get; set; }

    public MemorabiliaContext(DbContextOptions<MemorabiliaContext> options) 
        : base(options) { }        

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acquisition>()
                    .Property(x => x.Cost)
                    .HasPrecision(12, 2);     
        
        modelBuilder.Entity<Autograph>()
                    .Property(x => x.EstimatedValue)
                    .HasPrecision(12, 2);

        modelBuilder.Entity<AutographAuthentication>();
        modelBuilder.Entity<AutographImage>();
        modelBuilder.Entity<AutographSpot>();       
        modelBuilder.Entity<Collection>();
        modelBuilder.Entity<CollectionMemorabilia>();
        modelBuilder.Entity<Inscription>();

        modelBuilder.Entity<Entity.Memorabilia>()
                    .Property(x => x.EstimatedValue)
                    .HasPrecision(12, 2);

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

        modelBuilder.Entity<MemorabiliaForSale>()
                    .Property(x => x.BuyNowPrice)
                    .HasPrecision(12, 2);

        modelBuilder.Entity<MemorabiliaForSale>()
                    .Property(x => x.MinimumOfferPrice)
                    .HasPrecision(12, 2);

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

        modelBuilder.Entity<MemorabiliaTransactionSale>()
                    .Property(x => x.SaleAmount)
                    .HasPrecision(12, 2);

        modelBuilder.Entity<MemorabiliaTransactionTrade>()
                    .Property(x => x.CashIncludedAmount)
                    .HasPrecision(12, 2);

        modelBuilder.Entity<Offer>()
                    .Property(x => x.Amount)
                    .HasPrecision(12, 2);

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
        
        modelBuilder.Entity<ProjectMemorabiliaTeam>()
                    .Property(x => x.EstimatedCost)
                    .HasPrecision(12, 2);

        modelBuilder.Entity<ProjectPerson>()
                    .Property(x => x.EstimatedCost)
                    .HasPrecision(12, 2);

        modelBuilder.Entity<ProjectTeam>();         
        modelBuilder.Entity<ProjectWorldSeries>();

        modelBuilder.Entity<ProposeTrade>()
                    .Property(x => x.AmountTradeCreatorToReceive)
                    .HasPrecision(12, 2);

        modelBuilder.Entity<ProposeTrade>()
                    .Property(x => x.AmountTradeCreatorToSend)
                    .HasPrecision(12, 2);

        modelBuilder.Entity<ProposeTradeMemorabilia>();
        modelBuilder.Entity<SignatureIdentification>();
        modelBuilder.Entity<SignatureIdentificationImage>();
        modelBuilder.Entity<SignatureIdentificationPerson>();
        modelBuilder.Entity<SignatureReview>();
        modelBuilder.Entity<SignatureReviewImage>();
        modelBuilder.Entity<SignatureReviewUserResult>();
        modelBuilder.Entity<ThroughTheMail>();   
        
        modelBuilder.Entity<ThroughTheMailMemorabilia>()
                    .Property(x => x.Cost)
                    .HasPrecision(15, 2);
    }
}
