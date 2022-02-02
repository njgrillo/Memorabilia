using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;

namespace Memorabilia.Repository
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Acquisition>().Property(x => x.Cost).HasPrecision(12, 2);
            modelBuilder.Entity<Domain.Entities.AcquisitionType>();
            modelBuilder.Entity<Domain.Entities.AuthenticationCompany>();
            modelBuilder.Entity<Domain.Entities.Autograph>();
            modelBuilder.Entity<Domain.Entities.BaseballType>();
            modelBuilder.Entity<Domain.Entities.Brand>();
            modelBuilder.Entity<Domain.Entities.Color>();
            modelBuilder.Entity<Domain.Entities.Commissioner>();
            modelBuilder.Entity<Domain.Entities.Condition>();
            modelBuilder.Entity<Domain.Entities.Franchise>();
            modelBuilder.Entity<Domain.Entities.FullSizeHelmetType>();
            modelBuilder.Entity<Domain.Entities.GloveType>();
            modelBuilder.Entity<Domain.Entities.HelmetType>();
            modelBuilder.Entity<Domain.Entities.ImageType>();
            modelBuilder.Entity<Domain.Entities.InscriptionType>();
            modelBuilder.Entity<Domain.Entities.ItemType>();
            modelBuilder.Entity<Domain.Entities.ItemTypeBrand>();
            modelBuilder.Entity<Domain.Entities.ItemTypeSize>();
            modelBuilder.Entity<Domain.Entities.ItemTypeSport>();
            modelBuilder.Entity<Domain.Entities.ItemTypeSpot>();
            modelBuilder.Entity<Domain.Entities.JerseyLevelType>();
            modelBuilder.Entity<Domain.Entities.JerseyNumberType>();
            modelBuilder.Entity<Domain.Entities.JerseyType>();
            modelBuilder.Entity<Domain.Entities.MagazineType>();
            modelBuilder.Entity<Domain.Entities.Memorabilia>().Property(x => x.EstimatedValue).HasPrecision(12, 2);
            modelBuilder.Entity<Domain.Entities.MemorabiliaAcquisition>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaBaseballType>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaBrand>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaCommissioner>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaPerson>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaSize>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaSport>();
            modelBuilder.Entity<Domain.Entities.MemorabiliaTeam>();
            modelBuilder.Entity<Domain.Entities.Occupation>();
            modelBuilder.Entity<Domain.Entities.Person>();
            modelBuilder.Entity<Domain.Entities.PrivacyType>();
            modelBuilder.Entity<Domain.Entities.PurchaseType>();
            modelBuilder.Entity<Domain.Entities.Size>();
            modelBuilder.Entity<Domain.Entities.Sport>();
            modelBuilder.Entity<Domain.Entities.Spot>();
            modelBuilder.Entity<Domain.Entities.Team>();
            modelBuilder.Entity<Domain.Entities.WritingInstrument>();
            modelBuilder.Entity<Domain.Entities.User>();
        }
    }
}
