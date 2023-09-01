namespace Memorabilia.Repository;

public class DomainContext : DbContext, IDomainContext
{
    public DbSet<Entity.AwardDetail> AwardDetail { get; set; }

    public DbSet<Entity.AwardExclusionYear> AwardExclusionYear { get; set; }

    public DbSet<Entity.AwardType> AwardType { get; set; }

    public DbSet<Entity.College> College { get; set; }

    public DbSet<Entity.Person> Person { get; set; }

    public DbSet<Entity.PersonAward> PersonAward { get; set; }

    public DbSet<Entity.PersonTeam> PersonTeam { get; set; }

    public DbSet<Entity.Team> Team { get; set; }

    public DomainContext(DbContextOptions<DomainContext> options) 
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entity.AccomplishmentDetail>();
        modelBuilder.Entity<Entity.AccomplishmentType>();
        modelBuilder.Entity<Entity.AcquisitionType>();
        modelBuilder.Entity<Entity.AllStarDetail>();
        modelBuilder.Entity<Entity.AuthenticationCompany>();           
        modelBuilder.Entity<Entity.AwardDetail>();
        modelBuilder.Entity<Entity.AwardExclusionYear>();
        modelBuilder.Entity<Entity.AwardType>();
        modelBuilder.Entity<Entity.BammerType>();
        modelBuilder.Entity<Entity.BaseballType>();
        modelBuilder.Entity<Entity.BasketballType>();
        modelBuilder.Entity<Entity.BatType>();
        modelBuilder.Entity<Entity.Brand>();
        modelBuilder.Entity<Entity.CerealType>();
        modelBuilder.Entity<Entity.ChampionType>();
        modelBuilder.Entity<Entity.College>();
        modelBuilder.Entity<Entity.Color>();
        modelBuilder.Entity<Entity.Commissioner>();
        modelBuilder.Entity<Entity.Condition>();
        modelBuilder.Entity<Entity.Conference>();
        modelBuilder.Entity<Entity.DashboardItem>();
        modelBuilder.Entity<Entity.Division>();        
        modelBuilder.Entity<Entity.FigureSpecialtyType>();
        modelBuilder.Entity<Entity.FigureType>();
        modelBuilder.Entity<Entity.FootballType>();
        modelBuilder.Entity<Entity.Franchise>();
        modelBuilder.Entity<Entity.FranchiseHallOfFameType>();
        modelBuilder.Entity<Entity.GameStyleType>();
        modelBuilder.Entity<Entity.GloveType>();

        modelBuilder.Entity<Entity.HallOfFame>()
                    .Property(x => x.VotePercentage)
                    .HasPrecision(5, 2);

        modelBuilder.Entity<Entity.HelmetFinish>();
        modelBuilder.Entity<Entity.HelmetQualityType>();
        modelBuilder.Entity<Entity.HelmetType>();
        modelBuilder.Entity<Entity.ImageType>();
        modelBuilder.Entity<Entity.InscriptionType>();
        modelBuilder.Entity<Entity.InternationalHallOfFame>();
        modelBuilder.Entity<Entity.InternationalHallOfFameType>();
        modelBuilder.Entity<Entity.ItemType>();
        modelBuilder.Entity<Entity.ItemTypeGameStyleType>();
        modelBuilder.Entity<Entity.ItemTypeBrand>();
        modelBuilder.Entity<Entity.ItemTypeLevel>();
        modelBuilder.Entity<Entity.ItemTypeSize>();
        modelBuilder.Entity<Entity.ItemTypeSport>();
        modelBuilder.Entity<Entity.ItemTypeSpot>();
        modelBuilder.Entity<Entity.JerseyQualityType>();
        modelBuilder.Entity<Entity.JerseyStyleType>();
        modelBuilder.Entity<Entity.JerseyType>();
        modelBuilder.Entity<Entity.LeaderType>();
        modelBuilder.Entity<Entity.League>();
        modelBuilder.Entity<Entity.LeaguePresident>();
        modelBuilder.Entity<Entity.LevelType>();
        modelBuilder.Entity<Entity.MagazineType>();
        modelBuilder.Entity<Entity.Occupation>();
        modelBuilder.Entity<Entity.Orientation>();
        modelBuilder.Entity<Entity.Person>();
        modelBuilder.Entity<Entity.PersonAward>();
        modelBuilder.Entity<Entity.PersonNickname>();
        modelBuilder.Entity<Entity.PersonOccupation>();
        modelBuilder.Entity<Entity.PersonSport>();
        modelBuilder.Entity<Entity.PersonTeam>();
        modelBuilder.Entity<Entity.Pewter>();
        modelBuilder.Entity<Entity.PhotoType>();        
        modelBuilder.Entity<Entity.Position>();        
        modelBuilder.Entity<Entity.PriorityType>();
        modelBuilder.Entity<Entity.PrivacyType>();            
        modelBuilder.Entity<Entity.ProjectStatusType>();            
        modelBuilder.Entity<Entity.ProjectType>();            
        modelBuilder.Entity<Entity.PurchaseType>();
        modelBuilder.Entity<Entity.RecordType>();
        modelBuilder.Entity<Entity.Size>();
        modelBuilder.Entity<Entity.Sport>();
        modelBuilder.Entity<Entity.SportLeagueLevel>();
        modelBuilder.Entity<Entity.SportService>();
        modelBuilder.Entity<Entity.Spot>();
        modelBuilder.Entity<Entity.Team>();
        modelBuilder.Entity<Entity.TeamConference>();
        modelBuilder.Entity<Entity.TeamDivision>();
        modelBuilder.Entity<Entity.TeamLeague>();
        modelBuilder.Entity<Entity.TeamRoleType>();
        modelBuilder.Entity<Entity.ThroughTheMailFailureType>();
        modelBuilder.Entity<Entity.TransactionTradeType>();
        modelBuilder.Entity<Entity.TransactionType>();
        modelBuilder.Entity<Entity.User>();
        modelBuilder.Entity<Entity.UserDashboard>();
        modelBuilder.Entity<Entity.WritingInstrument>();
    }
}

