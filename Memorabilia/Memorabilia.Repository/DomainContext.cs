﻿using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Memorabilia.Repository
{
    public class DomainContext : DbContext, IDomainContext
    {
        public DomainContext(DbContextOptions<DomainContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcquisitionType>();
            modelBuilder.Entity<AuthenticationCompany>();
            modelBuilder.Entity<BaseballType>();
            modelBuilder.Entity<BasketballType>();
            modelBuilder.Entity<BatType>();
            modelBuilder.Entity<Brand>();
            modelBuilder.Entity<Color>();
            modelBuilder.Entity<Commissioner>();
            modelBuilder.Entity<Condition>();
            modelBuilder.Entity<Conference>();
            modelBuilder.Entity<DashboardItem>();
            modelBuilder.Entity<Division>();
            modelBuilder.Entity<FigureSpecialtyType>();
            modelBuilder.Entity<FigureType>();
            modelBuilder.Entity<FootballType>();
            modelBuilder.Entity<Franchise>();
            modelBuilder.Entity<GameStyleType>();
            modelBuilder.Entity<GloveType>();
            modelBuilder.Entity<HallOfFame>().Property(x => x.VotePercentage).HasPrecision(5, 2);
            modelBuilder.Entity<HelmetFinish>();
            modelBuilder.Entity<HelmetQualityType>();
            modelBuilder.Entity<HelmetType>();
            modelBuilder.Entity<ImageType>();
            modelBuilder.Entity<InscriptionType>();
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
            modelBuilder.Entity<League>();
            modelBuilder.Entity<LevelType>();
            modelBuilder.Entity<MagazineType>();
            modelBuilder.Entity<Occupation>();
            modelBuilder.Entity<Orientation>();
            modelBuilder.Entity<Person>();
            modelBuilder.Entity<PersonOccupation>();
            modelBuilder.Entity<PersonTeam>();
            modelBuilder.Entity<Pewter>();
            modelBuilder.Entity<PhotoType>();
            modelBuilder.Entity<PrivacyType>();
            modelBuilder.Entity<PurchaseType>();
            modelBuilder.Entity<Size>();
            modelBuilder.Entity<Sport>();
            modelBuilder.Entity<SportLeagueLevel>();
            modelBuilder.Entity<Spot>();
            modelBuilder.Entity<Team>();
            modelBuilder.Entity<TeamConference>();
            modelBuilder.Entity<TeamDivision>();
            modelBuilder.Entity<TeamLeague>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<UserDashboard>();
            modelBuilder.Entity<WritingInstrument>();
        }
    }
}

