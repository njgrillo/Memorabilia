namespace Memorabilia.Repository;

public class DomainContext(DbContextOptions<DomainContext> options) 
    : DbContext(options), IDomainContext
{
    public DbSet<AwardDetail> AwardDetail { get; set; }

    public DbSet<AwardExclusionYear> AwardExclusionYear { get; set; }

    public DbSet<AwardType> AwardType { get; set; }

    public DbSet<College> College { get; set; }

    public DbSet<ForumCategory> ForumCategory { get; set; }

    public DbSet<ForumEntry> ForumEntry { get; set; }

    public DbSet<ForumTopic> ForumTopic { get; set; }

    public DbSet<ForumTopicUserBookmark> ForumTopicUserBookmark { get; set; }

    public DbSet<Person> Person { get; set; }

    public DbSet<PersonAward> PersonAward { get; set; }

    public DbSet<PersonTeam> PersonTeam { get; set; }

    public DbSet<Team> Team { get; set; }

    public DbSet<User> User { get; set; }

    public DbSet<UserMessage> UserMessage { get; set; }

    public DbSet<UserMessageReply> UserMessageReply { get; set; }

    public DbSet<UserMessageReplyImage> UserMessageReplyImage { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccomplishmentDetail>();
        modelBuilder.Entity<AccomplishmentType>();
        modelBuilder.Entity<AcquisitionType>();
        modelBuilder.Entity<AllStarDetail>();
        modelBuilder.Entity<AuthenticationCompany>();           
        modelBuilder.Entity<AwardDetail>();
        modelBuilder.Entity<AwardExclusionYear>();
        modelBuilder.Entity<AwardType>();
        modelBuilder.Entity<BammerType>();
        modelBuilder.Entity<BaseballType>();
        modelBuilder.Entity<BasketballType>();
        modelBuilder.Entity<BatType>();
        modelBuilder.Entity<Brand>();
        modelBuilder.Entity<CerealType>();
        modelBuilder.Entity<ChampionType>();
        modelBuilder.Entity<College>();
        modelBuilder.Entity<Color>();
        modelBuilder.Entity<Commissioner>();
        modelBuilder.Entity<Condition>();
        modelBuilder.Entity<Conference>();
        modelBuilder.Entity<DashboardItem>();
        modelBuilder.Entity<Division>();        
        modelBuilder.Entity<FigureSpecialtyType>();
        modelBuilder.Entity<FigureType>();
        modelBuilder.Entity<FootballType>();
        modelBuilder.Entity<ForumCategory>();
        modelBuilder.Entity<ForumEntry>();
        modelBuilder.Entity<ForumEntryImage>();
        modelBuilder.Entity<ForumEntryUserRank>();
        modelBuilder.Entity<ForumTopic>();
        modelBuilder.Entity<Franchise>();
        modelBuilder.Entity<FranchiseHallOfFameType>();
        modelBuilder.Entity<GameStyleType>();
        modelBuilder.Entity<GloveType>();
        modelBuilder.Entity<HallOfFame>();
        modelBuilder.Entity<HelmetFinish>();
        modelBuilder.Entity<HelmetQualityType>();
        modelBuilder.Entity<HelmetType>();
        modelBuilder.Entity<ImageType>();
        modelBuilder.Entity<InscriptionType>();
        modelBuilder.Entity<InternationalHallOfFame>();
        modelBuilder.Entity<InternationalHallOfFameType>();
        modelBuilder.Entity<ItemType>();
        modelBuilder.Entity<ItemTypeGameStyleType>();
        modelBuilder.Entity<ItemTypeBrand>();
        modelBuilder.Entity<ItemTypeLevel>();
        modelBuilder.Entity<ItemTypeSize>();
        modelBuilder.Entity<ItemTypeSport>();
        modelBuilder.Entity<ItemTypeSpot>();
        modelBuilder.Entity<JerseyQualityType>();
        modelBuilder.Entity<JerseyStyleType>();
        modelBuilder.Entity<JerseyType>();
        modelBuilder.Entity<LeaderType>();
        modelBuilder.Entity<League>();
        modelBuilder.Entity<LeaguePresident>();
        modelBuilder.Entity<LevelType>();
        modelBuilder.Entity<MagazineType>();
        modelBuilder.Entity<Occupation>();
        modelBuilder.Entity<Orientation>();
        modelBuilder.Entity<Person>();
        modelBuilder.Entity<PersonAward>();
        modelBuilder.Entity<PersonNickname>();
        modelBuilder.Entity<PersonOccupation>();
        modelBuilder.Entity<PersonSport>();
        modelBuilder.Entity<PersonTeam>();
        modelBuilder.Entity<Pewter>();
        modelBuilder.Entity<PhotoType>();        
        modelBuilder.Entity<Position>();        
        modelBuilder.Entity<PriorityType>();
        modelBuilder.Entity<PrivacyType>();            
        modelBuilder.Entity<ProjectStatusType>();            
        modelBuilder.Entity<ProjectType>(); 
        modelBuilder.Entity<PurchaseType>();
        modelBuilder.Entity<RecordType>();
        modelBuilder.Entity<Role>();
        modelBuilder.Entity<RolePermission>();
        modelBuilder.Entity<Size>();
        modelBuilder.Entity<Sport>();
        modelBuilder.Entity<SportLeagueLevel>();
        modelBuilder.Entity<SportService>();
        modelBuilder.Entity<Spot>();
        modelBuilder.Entity<StripePaymentTransaction>();
        modelBuilder.Entity<Team>();
        modelBuilder.Entity<TeamConference>();
        modelBuilder.Entity<TeamDivision>();
        modelBuilder.Entity<TeamLeague>();
        modelBuilder.Entity<TeamRoleType>();
        modelBuilder.Entity<ThroughTheMailFailureType>();
        modelBuilder.Entity<TransactionTradeType>();
        modelBuilder.Entity<TransactionType>();
        modelBuilder.Entity<User>();
        modelBuilder.Entity<UserDashboard>();
        modelBuilder.Entity<UserMessage>();
        modelBuilder.Entity<UserMessageReply>();
        modelBuilder.Entity<UserMessageReplyImage>();
        modelBuilder.Entity<UserPaymentOption>();
        modelBuilder.Entity<UserRole>();
        modelBuilder.Entity<UserSocialMedia>();
        modelBuilder.Entity<WritingInstrument>();
    }
}

