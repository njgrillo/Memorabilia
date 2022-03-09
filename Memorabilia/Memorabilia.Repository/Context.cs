using Memorabilia.Domain;
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
            modelBuilder.Entity<Domain.Entities.Acquisition>().Property(x => x.Cost).HasPrecision(12, 2);
            modelBuilder.Entity<Domain.Entities.AcquisitionType>();
            modelBuilder.Entity<Domain.Entities.AuthenticationCompany>();
            modelBuilder.Entity<Domain.Entities.GameStyleType>();
            modelBuilder.Entity<Domain.Entities.Autograph>().Property(x => x.EstimatedValue).HasPrecision(12, 2);
            modelBuilder.Entity<Domain.Entities.AutographAuthentication>();
            modelBuilder.Entity<Domain.Entities.AutographImage>();
            modelBuilder.Entity<Domain.Entities.AutographSpot>();
            modelBuilder.Entity<Domain.Entities.AutographThroughTheMail>();
            modelBuilder.Entity<Domain.Entities.BaseballType>();
            modelBuilder.Entity<Domain.Entities.BasketballType>();
            modelBuilder.Entity<Domain.Entities.BatType>();
            modelBuilder.Entity<Domain.Entities.Brand>();
            modelBuilder.Entity<Domain.Entities.Color>();
            modelBuilder.Entity<Domain.Entities.Commissioner>();
            modelBuilder.Entity<Domain.Entities.Condition>();
            modelBuilder.Entity<Domain.Entities.Conference>();
            modelBuilder.Entity<Domain.Entities.Division>();
            modelBuilder.Entity<Domain.Entities.FigureSpecialtyType>();
            modelBuilder.Entity<Domain.Entities.FigureType>();
            modelBuilder.Entity<Domain.Entities.FootballType>();
            modelBuilder.Entity<Domain.Entities.Franchise>();            
            modelBuilder.Entity<Domain.Entities.GloveType>();
            modelBuilder.Entity<Domain.Entities.HallOfFame>().Property(x => x.VotePercentage).HasPrecision(5, 2);
            modelBuilder.Entity<Domain.Entities.HelmetFinish>();
            modelBuilder.Entity<Domain.Entities.HelmetQualityType>();
            modelBuilder.Entity<Domain.Entities.HelmetType>();
            modelBuilder.Entity<Domain.Entities.ImageType>();
            modelBuilder.Entity<Domain.Entities.Inscription>();
            modelBuilder.Entity<Domain.Entities.InscriptionType>();
            modelBuilder.Entity<Domain.Entities.ItemType>();
            modelBuilder.Entity<Domain.Entities.ItemTypeGameStyleType>();
            modelBuilder.Entity<Domain.Entities.ItemTypeBrand>();
            modelBuilder.Entity<Domain.Entities.ItemTypeLevel>();
            modelBuilder.Entity<Domain.Entities.ItemTypeSize>();
            modelBuilder.Entity<Domain.Entities.ItemTypeSport>();
            modelBuilder.Entity<Domain.Entities.ItemTypeSpot>();           
            modelBuilder.Entity<Domain.Entities.JerseyQualityType>();
            modelBuilder.Entity<Domain.Entities.JerseyStyleType>();
            modelBuilder.Entity<Domain.Entities.JerseyType>();
            modelBuilder.Entity<Domain.Entities.League>();
            modelBuilder.Entity<Domain.Entities.LevelType>();
            modelBuilder.Entity<Domain.Entities.MagazineType>();
            modelBuilder.Entity<Domain.Entities.Memorabilia>().Property(x => x.EstimatedValue).HasPrecision(12, 2);
            modelBuilder.Entity<Domain.Entities.MemorabiliaAcquisition>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaBaseball>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaBasketball>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaBat>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaBook>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaBrand>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaCanvas>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaCard>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaCommissioner>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaFigure>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaFootball>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaGame>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaHelmet>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaImage>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaJersey>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaLevelType>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaLithograph>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaMagazine>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaOrientation>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaPerson>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaPhoto>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaSize>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaSport>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaTeam>();
            modelBuilder.Entity<Domain.Entities.Occupation>();
            modelBuilder.Entity<Domain.Entities.Orientation>();
            modelBuilder.Entity<Domain.Entities.Person>();
            modelBuilder.Entity<Domain.Entities.Personalization>();
            modelBuilder.Entity<Domain.Entities.PersonOccupation>();
            modelBuilder.Entity<Domain.Entities.PersonTeam>();
            modelBuilder.Entity<Domain.Entities.Pewter>();
            modelBuilder.Entity<Domain.Entities.PhotoType>();
            modelBuilder.Entity<Domain.Entities.PrivacyType>();
            modelBuilder.Entity<Domain.Entities.PurchaseType>();
            modelBuilder.Entity<Domain.Entities.Size>();
            modelBuilder.Entity<Domain.Entities.Sport>();
            modelBuilder.Entity<Domain.Entities.SportLeagueLevel>();
            modelBuilder.Entity<Domain.Entities.Spot>();
            modelBuilder.Entity<Domain.Entities.Team>();
            modelBuilder.Entity<Domain.Entities.TeamConference>();
            modelBuilder.Entity<Domain.Entities.TeamDivision>();
            modelBuilder.Entity<Domain.Entities.TeamLeague>();
            modelBuilder.Entity<Domain.Entities.User>();
            modelBuilder.Entity<Domain.Entities.WritingInstrument>();            
        }
    }
}
