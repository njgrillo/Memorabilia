namespace Memorabilia.Repository;

public class HistoryContext(DbContextOptions<HistoryContext> options) 
    : DbContext(options), IHistoryContext
{
    public DbSet<MemorabiliaHistory> MemorabiliaHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcquisitionHistory>()
                    .ToTable("AcquisitionHistory", c => c.IsTemporal());

        modelBuilder.Entity<AuthenticationCompanyHistory>()
                    .ToTable("AuthenticationCompanyHistory", c => c.IsTemporal());

        modelBuilder.Entity<AutographHistory>()
                    .ToTable("AutographHistory", c => c.IsTemporal());

        modelBuilder.Entity<AutographAuthenticationHistory>()
                    .ToTable("AutographAuthenticationHistory", c => c.IsTemporal());

        modelBuilder.Entity<AutographImageHistory>()
                    .ToTable("AutographImageHistory", c => c.IsTemporal());

        modelBuilder.Entity<AutographSpotHistory>()
                    .ToTable("AutographSpotHistory", c => c.IsTemporal());

        modelBuilder.Entity<CollectionHistory>()
                    .ToTable("CollectionHistory", c => c.IsTemporal());

        modelBuilder.Entity<CollectionMemorabiliaHistory>()
                    .ToTable("CollectionMemorabiliaHistory", c => c.IsTemporal());

        modelBuilder.Entity<ForumEntryHistory>()
                    .ToTable("ForumEntryHistory", c => c.IsTemporal());

        modelBuilder.Entity<ForumEntryImageHistory>()
                    .ToTable("ForumEntryImageHistory", c => c.IsTemporal());

        modelBuilder.Entity<ForumEntryUserRankHistory>()
                    .ToTable("ForumEntryUserRankHistory", c => c.IsTemporal());

        modelBuilder.Entity<InscriptionHistory>()
                    .ToTable("InscriptionHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaAcquisitionHistory>()
                    .ToTable("MemorabiliaAcquisitionHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaBammerHistory>()
                    .ToTable("MemorabiliaBammerHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaBaseballHistory>()
                    .ToTable("MemorabiliaBaseballHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaBasketballHistory>()
                    .ToTable("MemorabiliaBasketballHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaBatHistory>()
                    .ToTable("MemorabiliaBatHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaBobbleheadHistory>()
                    .ToTable("MemorabiliaBobbleheadHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaBookHistory>()
                    .ToTable("MemorabiliaBookHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaBrandHistory>()
                    .ToTable("MemorabiliaBrandHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaCardHistory>()
                    .ToTable("MemorabiliaCardHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaCerealHistory>()
                    .ToTable("MemorabiliaCerealHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaCommissionerHistory>()
                    .ToTable("MemorabiliaCommissionerHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaFigureHistory>()
                    .ToTable("MemorabiliaFigureHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaFirstDayCoverHistory>()
                    .ToTable("MemorabiliaFirstDayCoverHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaFootballHistory>()
                    .ToTable("MemorabiliaFootballHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaForSaleHistory>()
                    .ToTable("MemorabiliaForSaleHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaGameHistory>()
                    .ToTable("MemorabiliaGameHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaGloveHistory>()
                    .ToTable("MemorabiliaGloveHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaHelmetHistory>()
                    .ToTable("MemorabiliaHelmetHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaHistory>()
                    .ToTable("MemorabiliaHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaImageHistory>()
                    .ToTable("MemorabiliaImageHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaJerseyHistory>()
                    .ToTable("MemorabiliaJerseyHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaJerseyNumberHistory>()
                    .ToTable("MemorabiliaJerseyNumberHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaLevelTypeHistory>()
                    .ToTable("MemorabiliaLevelTypeHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaMagazineHistory>()
                    .ToTable("MemorabiliaMagazineHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaPersonHistory>()
                    .ToTable("MemorabiliaPersonHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaPictureHistory>()
                    .ToTable("MemorabiliaPictureHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaSizeHistory>()
                    .ToTable("MemorabiliaSizeHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaSportHistory>()
                    .ToTable("MemorabiliaSportHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaTeamHistory>()
                    .ToTable("MemorabiliaTeamHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaTransactionHistory>()
                    .ToTable("MemorabiliaTransactionHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaTransactionSaleHistory>()
                    .ToTable("MemorabiliaTransactionSaleHistory", c => c.IsTemporal());

        modelBuilder.Entity<MemorabiliaTransactionTradeHistory>()
                    .ToTable("MemorabiliaTransactionTradeHistory", c => c.IsTemporal());

        modelBuilder.Entity<OfferHistory>()
                    .ToTable("OfferHistory", c => c.IsTemporal());

        modelBuilder.Entity<PrivateSigningHistory>()
                    .ToTable("PrivateSigningHistory", c => c.IsTemporal());

        modelBuilder.Entity<PrivateSigningAuthenticationCompanyHistory>()
                    .ToTable("PrivateSigningAuthenticationCompanyHistory", c => c.IsTemporal());

        modelBuilder.Entity<PrivateSigningCustomItemGroupHistory>()
                    .ToTable("PrivateSigningCustomItemGroupHistory", c => c.IsTemporal());

        modelBuilder.Entity<PrivateSigningCustomItemTypeGroupDetailHistory>()
                    .ToTable("PrivateSigningCustomItemTypeGroupDetailHistory", c => c.IsTemporal());

        modelBuilder.Entity<PrivateSigningCustomItemTypeGroupHistory>()
                    .ToTable("PrivateSigningCustomItemTypeGroupHistory", c => c.IsTemporal());

        modelBuilder.Entity<PrivateSigningPersonHistory>()
                    .ToTable("PrivateSigningPersonHistory", c => c.IsTemporal());

        modelBuilder.Entity<PrivateSigningPersonDetailHistory>()
                    .ToTable("PrivateSigningPersonDetailHistory", c => c.IsTemporal());

        modelBuilder.Entity<PrivateSigningPersonExcludeItemTypeHistory>()
                    .ToTable("PrivateSigningPersonExcludeItemTypeHistory", c => c.IsTemporal());

        modelBuilder.Entity<PrivateSigningPromoterProvidedItemHistory>()
                    .ToTable("PrivateSigningPromoterProvidedItemHistory", c => c.IsTemporal());

        modelBuilder.Entity<PrivateSigningPersonHistory>()
                    .ToTable("PrivateSigningPersonHistory", c => c.IsTemporal());

        modelBuilder.Entity<ProjectHistory>()
                    .ToTable("ProjectHistory", c => c.IsTemporal());

        modelBuilder.Entity<ProjectBaseballHistory>()
                    .ToTable("ProjectBaseballHistory", c => c.IsTemporal());

        modelBuilder.Entity<ProjectCardHistory>()
                    .ToTable("ProjectCardHistory", c => c.IsTemporal());

        modelBuilder.Entity<ProjectHallOfFameHistory>()
                    .ToTable("ProjectHallOfFameHistory", c => c.IsTemporal());

        modelBuilder.Entity<ProjectHelmetHistory>()
                    .ToTable("ProjectHelmetHistory", c => c.IsTemporal());

        modelBuilder.Entity<ProjectItemHistory>()
                    .ToTable("ProjectItemHistory", c => c.IsTemporal());

        modelBuilder.Entity<ProjectMemorabiliaTeamHistory>()
                    .ToTable("ProjectMemorabiliaTeamHistory", c => c.IsTemporal());

        modelBuilder.Entity<ProjectPersonHistory>()
                    .ToTable("ProjectPersonHistory", c => c.IsTemporal());

        modelBuilder.Entity<ProjectTeamHistory>()
                    .ToTable("ProjectTeamHistory", c => c.IsTemporal());

        modelBuilder.Entity<ProjectWorldSeriesHistory>()
                    .ToTable("ProjectWorldSeriesHistory", c => c.IsTemporal());

        modelBuilder.Entity<PromoterProvidedItemHistory>()
                    .ToTable("PromoterProvidedItemHistory", c => c.IsTemporal());

        modelBuilder.Entity<ProposeTradeHistory>()
                    .ToTable("ProposeTradeHistory", c => c.IsTemporal());

        modelBuilder.Entity<ProposeTradeMemorabiliaHistory>()
                    .ToTable("ProposeTradeMemorabiliaHistory", c => c.IsTemporal());

        modelBuilder.Entity<SignatureIdentificationHistory>()
                    .ToTable("SignatureIdentificationHistory", c => c.IsTemporal());

        modelBuilder.Entity<SignatureIdentificationImageHistory>()
                    .ToTable("SignatureIdentificationImageHistory", c => c.IsTemporal());

        modelBuilder.Entity<SignatureIdentificationPersonHistory>()
                    .ToTable("SignatureIdentificationPersonHistory", c => c.IsTemporal());

        modelBuilder.Entity<SignatureReviewHistory>()
                    .ToTable("SignatureReviewHistory", c => c.IsTemporal());

        modelBuilder.Entity<SignatureReviewImageHistory>()
                    .ToTable("SignatureReviewImageHistory", c => c.IsTemporal());

        modelBuilder.Entity<SignatureReviewUserResultHistory>()
                    .ToTable("SignatureReviewUserResultHistory", c => c.IsTemporal());

        modelBuilder.Entity<ThroughTheMailHistory>()
                    .ToTable("ThroughTheMailHistory", c => c.IsTemporal());

        modelBuilder.Entity<ThroughTheMailMemorabiliaHistory>()
                    .ToTable("ThroughTheMailMemorabiliaHistory", c => c.IsTemporal());

        modelBuilder.Entity<UserDashboardHistory>()
                    .ToTable("UserDashboardHistory", c => c.IsTemporal());

        modelBuilder.Entity<UserHistory>()
                    .ToTable("UserHistory", c => c.IsTemporal());

        modelBuilder.Entity<UserMessageHistory>()
                    .ToTable("UserMessageHistory", c => c.IsTemporal());        

        modelBuilder.Entity<UserMessageReplyHistory>()
                    .ToTable("UserMessageReplyHistory", c => c.IsTemporal());

        modelBuilder.Entity<UserMessageReplyImageHistory>()
                    .ToTable("UserMessageReplyImageHistory", c => c.IsTemporal());
    }
}
