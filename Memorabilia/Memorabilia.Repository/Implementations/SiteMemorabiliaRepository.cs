namespace Memorabilia.Repository.Implementations;

public class SiteMemorabiliaRepository(MemorabiliaContext context, IMemoryCache memoryCache)
    : MemorabiliaRepository<Entity.Memorabilia>(context, memoryCache), ISiteMemorabiliaRepository
{
    private IQueryable<Entity.Memorabilia> Memorabilia
        => Items.Include(memorabilia => memorabilia.Autographs)
                .Include("Autographs.Authentications")
                .Include("Autographs.Images")
                .Include("Autographs.Inscriptions")
                .Include("Autographs.Person")
                .Include("Autographs.Spot")
                .Include(memorabilia => memorabilia.Bammer)
                .Include(memorabilia => memorabilia.Baseball)
                .Include(memorabilia => memorabilia.Basketball)
                .Include(memorabilia => memorabilia.Bat)
                .Include(memorabilia => memorabilia.Bobblehead)
                .Include(memorabilia => memorabilia.Book)
                .Include(memorabilia => memorabilia.Brand)
                .Include(memorabilia => memorabilia.Card)
                .Include(memorabilia => memorabilia.Cereal)
                .Include(memorabilia => memorabilia.Commissioner)
                .Include(memorabilia => memorabilia.Figure)
                .Include(memorabilia => memorabilia.FirstDayCover)
                .Include(memorabilia => memorabilia.Football)
                .Include(memorabilia => memorabilia.ForSale)
                .Include(memorabilia => memorabilia.Game)
                .Include(memorabilia => memorabilia.Glove)
                .Include(memorabilia => memorabilia.Helmet)
                .Include(memorabilia => memorabilia.Images)
                .Include(memorabilia => memorabilia.Jersey)
                .Include(memorabilia => memorabilia.JerseyNumber)
                .Include(memorabilia => memorabilia.LevelType)
                .Include(memorabilia => memorabilia.Magazine)
                .Include(memorabilia => memorabilia.People)
                .Include(memorabilia => memorabilia.Picture)
                .Include(memorabilia => memorabilia.Size)
                .Include(memorabilia => memorabilia.Sports)
                .Include(memorabilia => memorabilia.Teams);

    public override async Task<Entity.Memorabilia> Get(int id)
        => await Memorabilia.SingleOrDefaultAsync(memorabilia => memorabilia.Id == id);

    public async Task<PagedResult<Entity.Memorabilia>> GetAll(PageInfo pageInfo,
                                                              MemorabiliaSearchCriteria memorabiliaSearchCriteria = null,
                                                              int? userId = null)
    {
        var query =
            from memorabilia in Context.Memorabilia
            where memorabilia.PrivacyTypeId == Constant.PrivacyType.Public.Id
              && (memorabiliaSearchCriteria.AutographFilter == Constant.AutographFilter.None || (memorabiliaSearchCriteria.AutographFilter == Constant.AutographFilter.WithAutographs && memorabilia.Autographs.Count != 0) || (memorabiliaSearchCriteria.AutographFilter == Constant.AutographFilter.WithoutAutographs && memorabilia.Autographs.Count == 0))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.NotAuthenticated && memorabilia.Autographs.Any(autograph => autograph.Authentications.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.Authenticated && memorabilia.Autographs.Any(autograph => autograph.Authentications.Count != 0)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.ColorIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.ColorIds.Contains(autograph.ColorId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.ConditionIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.ConditionIds.Contains(autograph.ConditionId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.FranchiseIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.Team.FranchiseId).Any(franchiseId => memorabiliaSearchCriteria.AutographSearchCriteria.FranchiseIds.Contains(franchiseId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.Grade.HasValue || memorabilia.Autographs.Any(autograph => autograph.Grade == memorabiliaSearchCriteria.AutographSearchCriteria.Grade.Value))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.NoImages && memorabilia.Autographs.Any(autograph => autograph.Images.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.Images && memorabilia.Autographs.Any(autograph => autograph.Images.Count != 0)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.NoInscription && memorabilia.Autographs.Any(autograph => autograph.Inscriptions.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.Inscription && memorabilia.Autographs.Any(autograph => autograph.Inscriptions.Count != 0)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.People.Count == 0 || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.PersonIds.Contains(autograph.PersonId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.NotPersonalized && memorabilia.Autographs.Any(autograph => autograph.Personalization == null)) || (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.Personalized && memorabilia.Autographs.Any(autograph => autograph.Personalization != null)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SportIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Sports.Select(sport => sport.SportId).Any(sportId => memorabiliaSearchCriteria.AutographSearchCriteria.SportIds.Contains(sportId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SportLeagueLevelIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.Team.Franchise.SportLeagueLevel.Id).Any(sportLeagueLevelId => memorabiliaSearchCriteria.AutographSearchCriteria.SportLeagueLevelIds.Contains(sportLeagueLevelId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SpotIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.SpotIds.Contains(autograph.Spot.SpotId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.Teams.Count == 0 || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.TeamId).Any(teamId => memorabiliaSearchCriteria.AutographSearchCriteria.TeamIds.Contains(teamId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.WritingInstrumentIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.WritingInstrumentIds.Contains(autograph.WritingInstrumentId)))
              && (!memorabiliaSearchCriteria.BrandIds.Any() || (memorabilia.Brand != null && memorabiliaSearchCriteria.BrandIds.Contains(memorabilia.Brand.BrandId)))
              && (memorabiliaSearchCriteria.BuyNowFilter == Constant.BuyNowFilter.None || (memorabiliaSearchCriteria.BuyNowFilter == Constant.BuyNowFilter.BuyNow && memorabilia.ForSale != null && memorabilia.ForSale.BuyNowPrice != null) || (memorabiliaSearchCriteria.BuyNowFilter == Constant.BuyNowFilter.IsNotBuyNow && (memorabilia.ForSale == null || memorabilia.ForSale.BuyNowPrice == null)))
              && (!memorabiliaSearchCriteria.ConditionIds.Any() || (memorabilia.ConditionId.HasValue && memorabiliaSearchCriteria.ConditionIds.Contains(memorabilia.ConditionId.Value)))
              && (!memorabiliaSearchCriteria.FranchiseIds.Any() || memorabilia.Teams.Select(team => team.Team.Franchise.Id).Any(franchiseId => memorabiliaSearchCriteria.FranchiseIds.Contains(franchiseId)))
              && (!memorabiliaSearchCriteria.GameStyleTypeIds.Any() || (memorabilia.Game != null && memorabiliaSearchCriteria.GameStyleTypeIds.Contains(memorabilia.Game.GameStyleTypeId)))
              && (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.None || (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.NoImages && memorabilia.Images.Count == 0) || (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.Images && memorabilia.Images.Count != 0))
              && (userId == null || memorabilia.UserId != userId)
              && (!memorabiliaSearchCriteria.ItemTypeIds.Any() || memorabiliaSearchCriteria.ItemTypeIds.Contains(memorabilia.ItemTypeId))
              && (!memorabiliaSearchCriteria.LevelTypeIds.Any() || (memorabilia.LevelType != null && memorabiliaSearchCriteria.LevelTypeIds.Contains(memorabilia.LevelType.LevelTypeId)))
              && (memorabiliaSearchCriteria.MakeOfferFilter == Constant.MakeOfferFilter.None || (memorabiliaSearchCriteria.MakeOfferFilter == Constant.MakeOfferFilter.MakeOffer && memorabilia.ForSale != null && memorabilia.ForSale.AllowBestOffer) || (memorabiliaSearchCriteria.MakeOfferFilter == Constant.MakeOfferFilter.NotMakeOffer && (memorabilia.ForSale == null || !memorabilia.ForSale.AllowBestOffer)))
              && (memorabiliaSearchCriteria.People.Count == 0 || memorabilia.People.Any(person => memorabiliaSearchCriteria.PersonIds.Contains(person.PersonId)))
              && (memorabiliaSearchCriteria.SaleFilter == Constant.SaleFilter.None || (memorabiliaSearchCriteria.SaleFilter == Constant.SaleFilter.ForSale && memorabilia.ForSale != null) || (memorabiliaSearchCriteria.SaleFilter == Constant.SaleFilter.NotForSale && memorabilia.ForSale == null))
              && (!memorabiliaSearchCriteria.SizeIds.Any() || (memorabilia.Size != null && memorabiliaSearchCriteria.SizeIds.Contains(memorabilia.Size.SizeId)))
              && (!memorabiliaSearchCriteria.SportIds.Any() || memorabilia.Sports.Any(sport => memorabiliaSearchCriteria.SportIds.Contains(sport.SportId)))
              && (!memorabiliaSearchCriteria.SportLeagueLevelIds.Any() || memorabilia.Teams.Any(team => memorabiliaSearchCriteria.SportLeagueLevelIds.Contains(team.Team.Franchise.SportLeagueLevel.Id)))
              && (memorabiliaSearchCriteria.Teams.Count == 0 || memorabilia.Teams.Any(team => memorabiliaSearchCriteria.TeamIds.Contains(team.TeamId)))
              && (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.None || (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.ForTrade && memorabilia.ForTrade) || (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.NotForTrade && !memorabilia.ForTrade))
            orderby memorabilia.CreateDate descending
            select new Entity.Memorabilia(memorabilia);

        return await query.ToPagedResult(pageInfo);
    }

    public async Task<PagedResult<Entity.Memorabilia>> GetAllByUser(int userId,
                                                                    PageInfo pageInfo,
                                                                    MemorabiliaSearchCriteria memorabiliaSearchCriteria = null)
    {
        var query =
            from memorabilia in Context.Memorabilia
            where memorabilia.PrivacyTypeId == Constant.PrivacyType.Public.Id
              && memorabilia.UserId == userId
              && (memorabiliaSearchCriteria.AutographFilter == Constant.AutographFilter.None || (memorabiliaSearchCriteria.AutographFilter == Constant.AutographFilter.WithAutographs && memorabilia.Autographs.Count != 0) || (memorabiliaSearchCriteria.AutographFilter == Constant.AutographFilter.WithoutAutographs && memorabilia.Autographs.Count == 0))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.NotAuthenticated && memorabilia.Autographs.Any(autograph => autograph.Authentications.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.Authenticated && memorabilia.Autographs.Any(autograph => autograph.Authentications.Count != 0)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.ColorIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.ColorIds.Contains(autograph.ColorId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.ConditionIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.ConditionIds.Contains(autograph.ConditionId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.FranchiseIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.Team.FranchiseId).Any(franchiseId => memorabiliaSearchCriteria.AutographSearchCriteria.FranchiseIds.Contains(franchiseId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.Grade.HasValue || memorabilia.Autographs.Any(autograph => autograph.Grade == memorabiliaSearchCriteria.AutographSearchCriteria.Grade.Value))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.NoImages && memorabilia.Autographs.Any(autograph => autograph.Images.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.Images && memorabilia.Autographs.Any(autograph => autograph.Images.Count != 0)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.NoInscription && memorabilia.Autographs.Any(autograph => autograph.Inscriptions.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.Inscription && memorabilia.Autographs.Any(autograph => autograph.Inscriptions.Count != 0)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.People.Count == 0 || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.PersonIds.Contains(autograph.PersonId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.NotPersonalized && memorabilia.Autographs.Any(autograph => autograph.Personalization == null)) || (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.Personalized && memorabilia.Autographs.Any(autograph => autograph.Personalization != null)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SportIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Sports.Select(sport => sport.SportId).Any(sportId => memorabiliaSearchCriteria.AutographSearchCriteria.SportIds.Contains(sportId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SportLeagueLevelIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.Team.Franchise.SportLeagueLevel.Id).Any(sportLeagueLevelId => memorabiliaSearchCriteria.AutographSearchCriteria.SportLeagueLevelIds.Contains(sportLeagueLevelId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SpotIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.SpotIds.Contains(autograph.Spot.SpotId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.Teams.Count == 0 || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.TeamId).Any(teamId => memorabiliaSearchCriteria.AutographSearchCriteria.TeamIds.Contains(teamId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.WritingInstrumentIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.WritingInstrumentIds.Contains(autograph.WritingInstrumentId)))
              && (!memorabiliaSearchCriteria.BrandIds.Any() || (memorabilia.Brand != null && memorabiliaSearchCriteria.BrandIds.Contains(memorabilia.Brand.BrandId)))
              && (memorabiliaSearchCriteria.BuyNowFilter == Constant.BuyNowFilter.None || (memorabiliaSearchCriteria.BuyNowFilter == Constant.BuyNowFilter.BuyNow && memorabilia.ForSale != null && memorabilia.ForSale.BuyNowPrice != null) || (memorabiliaSearchCriteria.BuyNowFilter == Constant.BuyNowFilter.IsNotBuyNow && (memorabilia.ForSale == null || memorabilia.ForSale.BuyNowPrice == null)))
              && (!memorabiliaSearchCriteria.ConditionIds.Any() || (memorabilia.ConditionId.HasValue && memorabiliaSearchCriteria.ConditionIds.Contains(memorabilia.ConditionId.Value)))
              && (!memorabiliaSearchCriteria.FranchiseIds.Any() || memorabilia.Teams.Select(team => team.Team.Franchise.Id).Any(franchiseId => memorabiliaSearchCriteria.FranchiseIds.Contains(franchiseId)))
              && (!memorabiliaSearchCriteria.GameStyleTypeIds.Any() || (memorabilia.Game != null && memorabiliaSearchCriteria.GameStyleTypeIds.Contains(memorabilia.Game.GameStyleTypeId)))
              && (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.None || (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.NoImages && memorabilia.Images.Count == 0) || (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.Images && memorabilia.Images.Count != 0))
              && (!memorabiliaSearchCriteria.ItemTypeIds.Any() || memorabiliaSearchCriteria.ItemTypeIds.Contains(memorabilia.ItemTypeId))
              && (!memorabiliaSearchCriteria.LevelTypeIds.Any() || (memorabilia.LevelType != null && memorabiliaSearchCriteria.LevelTypeIds.Contains(memorabilia.LevelType.LevelTypeId)))
              && (memorabiliaSearchCriteria.MakeOfferFilter == Constant.MakeOfferFilter.None || (memorabiliaSearchCriteria.MakeOfferFilter == Constant.MakeOfferFilter.MakeOffer && memorabilia.ForSale != null && memorabilia.ForSale.AllowBestOffer) || (memorabiliaSearchCriteria.MakeOfferFilter == Constant.MakeOfferFilter.NotMakeOffer && (memorabilia.ForSale == null || !memorabilia.ForSale.AllowBestOffer)))
              && (memorabiliaSearchCriteria.People.Count == 0 || memorabilia.People.Any(person => memorabiliaSearchCriteria.PersonIds.Contains(person.PersonId)))
              && (memorabiliaSearchCriteria.SaleFilter == Constant.SaleFilter.None || (memorabiliaSearchCriteria.SaleFilter == Constant.SaleFilter.ForSale && memorabilia.ForSale != null) || (memorabiliaSearchCriteria.SaleFilter == Constant.SaleFilter.NotForSale && memorabilia.ForSale == null))
              && (!memorabiliaSearchCriteria.SizeIds.Any() || (memorabilia.Size != null && memorabiliaSearchCriteria.SizeIds.Contains(memorabilia.Size.SizeId)))
              && (!memorabiliaSearchCriteria.SportIds.Any() || memorabilia.Sports.Any(sport => memorabiliaSearchCriteria.SportIds.Contains(sport.SportId)))
              && (!memorabiliaSearchCriteria.SportLeagueLevelIds.Any() || memorabilia.Teams.Any(team => memorabiliaSearchCriteria.SportLeagueLevelIds.Contains(team.Team.Franchise.SportLeagueLevel.Id)))
              && (memorabiliaSearchCriteria.Teams.Count == 0 || memorabilia.Teams.Any(team => memorabiliaSearchCriteria.TeamIds.Contains(team.TeamId)))
              && (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.None || (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.ForTrade && memorabilia.ForTrade) || (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.NotForTrade && !memorabilia.ForTrade))
            orderby memorabilia.CreateDate descending
            select new Entity.Memorabilia(memorabilia);

        return await query.ToPagedResult(pageInfo);
    }
}
