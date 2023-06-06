using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class MemorabiliaItemRepository : MemorabiliaRepository<Domain.Entities.Memorabilia>, IMemorabiliaItemRepository
{
    public MemorabiliaItemRepository(MemorabiliaContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

    private IQueryable<Domain.Entities.Memorabilia> Memorabilia => Items.Include(memorabilia => memorabilia.Autographs)
                                                                        .Include("Autographs.Acquisition")
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
                                                                        .Include(memorabilia => memorabilia.CollectionMemorabilias)
                                                                        .Include(memorabilia => memorabilia.Commissioner)
                                                                        .Include(memorabilia => memorabilia.Figure)
                                                                        .Include(memorabilia => memorabilia.FirstDayCover)
                                                                        .Include(memorabilia => memorabilia.Football)
                                                                        .Include(memorabilia => memorabilia.Game)
                                                                        .Include(memorabilia => memorabilia.Glove)
                                                                        .Include(memorabilia => memorabilia.Helmet)
                                                                        .Include(memorabilia => memorabilia.Images)
                                                                        .Include(memorabilia => memorabilia.Jersey)
                                                                        .Include(memorabilia => memorabilia.JerseyNumber)
                                                                        .Include(memorabilia => memorabilia.LevelType)
                                                                        .Include(memorabilia => memorabilia.Magazine)
                                                                        .Include(memorabilia => memorabilia.MemorabiliaAcquisition)
                                                                        .Include(memorabilia => memorabilia.MemorabiliaAcquisition.Acquisition)
                                                                        .Include(memorabilia => memorabilia.People)
                                                                        .Include(memorabilia => memorabilia.Picture)
                                                                        .Include(memorabilia => memorabilia.Size)
                                                                        .Include(memorabilia => memorabilia.Sports)
                                                                        .Include(memorabilia => memorabilia.Teams)
                                                                        .Include(memorabilia => memorabilia.User);

    public override async Task Add(Domain.Entities.Memorabilia item, CancellationToken cancellationToken = default)
    {
        await base.Add(item, cancellationToken);
    }

    public override async Task<Domain.Entities.Memorabilia> Get(int id)
    {
        return await Memorabilia.SingleOrDefaultAsync(memorabilia => memorabilia.Id == id);
    }

    public int[] GetAcquisitionTypeIds(int userId)
    {
        return Items.Where(memorabilia => memorabilia.UserId == userId && memorabilia.MemorabiliaAcquisition.Acquisition != null)
                    .Select(memorabilia => memorabilia.MemorabiliaAcquisition.Acquisition.AcquisitionTypeId)
                    .ToArray();
    }

    public async Task<IEnumerable<Domain.Entities.Memorabilia>> GetAll(int userId)
    {
        var query =
            from memorabilia in Context.Memorabilia
            where memorabilia.UserId == userId
            select new Domain.Entities.Memorabilia(memorabilia);

        return await query.ToListAsync();
    }

    public async Task<PagedResult<Domain.Entities.Memorabilia>> GetAll(
        int userId,
        PageInfo pageInfo,
        MemorabiliaSearchCriteria memorabiliaSearchCriteria = null)
    {
        var query =
            from memorabilia in Context.Memorabilia
            where memorabilia.UserId == userId
              && (!memorabiliaSearchCriteria.AcquiredDateBegin.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.AcquiredDate >= memorabiliaSearchCriteria.AcquiredDateBegin))
              && (!memorabiliaSearchCriteria.AcquiredDateEnd.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.AcquiredDate <= memorabiliaSearchCriteria.AcquiredDateEnd))
              && (!memorabiliaSearchCriteria.AcquisitionTypeIds.Any() || (memorabilia.MemorabiliaAcquisition != null && memorabiliaSearchCriteria.AcquisitionTypeIds.Contains(memorabilia.MemorabiliaAcquisition.Acquisition.AcquisitionTypeId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateBegin.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.AcquiredDate >= memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateBegin.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateEnd.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.AcquiredDate <= memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateEnd.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquisitionTypeIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.AcquisitionTypeIds.Contains(autograph.Acquisition.AcquisitionTypeId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Domain.Constants.AuthenticationFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Domain.Constants.AuthenticationFilter.NotAuthenticated && memorabilia.Autographs.Any(autograph => !autograph.Authentications.Any())) || (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Domain.Constants.AuthenticationFilter.Authenticated && memorabilia.Autographs.Any(autograph => autograph.Authentications.Any())))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.ColorIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.ColorIds.Contains(autograph.ColorId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.ConditionIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.ConditionIds.Contains(autograph.ConditionId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.CostLow.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.Cost >= memorabiliaSearchCriteria.AutographSearchCriteria.CostLow.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.CostHigh.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.Cost <= memorabiliaSearchCriteria.AutographSearchCriteria.CostHigh.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueLow.HasValue || memorabilia.Autographs.Any(autograph => autograph.EstimatedValue >= memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueLow.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueHigh.HasValue || memorabilia.Autographs.Any(autograph => autograph.EstimatedValue <= memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueHigh.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.FranchiseIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.Team.FranchiseId).Any(franchiseId => memorabiliaSearchCriteria.AutographSearchCriteria.FranchiseIds.Contains(franchiseId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.Grade.HasValue || memorabilia.Autographs.Any(autograph => autograph.Grade == memorabiliaSearchCriteria.AutographSearchCriteria.Grade.Value))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Domain.Constants.ImageFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Domain.Constants.ImageFilter.NoImages && memorabilia.Autographs.Any(autograph => !autograph.Images.Any())) || (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Domain.Constants.ImageFilter.Images && memorabilia.Autographs.Any(autograph => autograph.Images.Any())))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Domain.Constants.InscriptionFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Domain.Constants.InscriptionFilter.NoInscription && memorabilia.Autographs.Any(autograph => !autograph.Inscriptions.Any())) || (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Domain.Constants.InscriptionFilter.Inscription && memorabilia.Autographs.Any(autograph => autograph.Inscriptions.Any())))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.People.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.PersonIds.Contains(autograph.PersonId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Domain.Constants.PersonalizationFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Domain.Constants.PersonalizationFilter.NotPersonalized && memorabilia.Autographs.Any(autograph => autograph.Personalization == null)) || (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Domain.Constants.PersonalizationFilter.Personalized && memorabilia.Autographs.Any(autograph => autograph.Personalization != null)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SportIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Sports.Select(sport => sport.SportId).Any(sportId => memorabiliaSearchCriteria.AutographSearchCriteria.SportIds.Contains(sportId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SportLeagueLevelIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.Team.Franchise.SportLeagueLevel.Id).Any(sportLeagueLevelId => memorabiliaSearchCriteria.AutographSearchCriteria.SportLeagueLevelIds.Contains(sportLeagueLevelId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SpotIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.SpotIds.Contains(autograph.Spot.SpotId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.Teams.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.TeamId).Any(teamId => memorabiliaSearchCriteria.AutographSearchCriteria.TeamIds.Contains(teamId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.WritingInstrumentIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.WritingInstrumentIds.Contains(autograph.WritingInstrumentId)))
              && (!memorabiliaSearchCriteria.BrandIds.Any() || (memorabilia.Brand != null && memorabiliaSearchCriteria.BrandIds.Contains(memorabilia.Brand.BrandId)))
              && (!memorabiliaSearchCriteria.ConditionIds.Any() || (memorabilia.ConditionId.HasValue && memorabiliaSearchCriteria.ConditionIds.Contains(memorabilia.ConditionId.Value)))
              && (!memorabiliaSearchCriteria.CostLow.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.Cost >= memorabiliaSearchCriteria.CostLow.Value))
              && (!memorabiliaSearchCriteria.CostHigh.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.Cost <= memorabiliaSearchCriteria.CostHigh.Value))
              && (!memorabiliaSearchCriteria.EstimatedValueLow.HasValue || memorabilia.EstimatedValue >= memorabiliaSearchCriteria.EstimatedValueLow.Value)
              && (!memorabiliaSearchCriteria.EstimatedValueHigh.HasValue || memorabilia.EstimatedValue <= memorabiliaSearchCriteria.EstimatedValueHigh.Value)
              && (!memorabiliaSearchCriteria.FranchiseIds.Any() || memorabilia.Teams.Select(team => team.Team.Franchise.Id).Any(franchiseId => memorabiliaSearchCriteria.FranchiseIds.Contains(franchiseId)))
              && (!memorabiliaSearchCriteria.GameStyleTypeIds.Any() || (memorabilia.Game != null && memorabiliaSearchCriteria.GameStyleTypeIds.Contains(memorabilia.Game.GameStyleTypeId)))
              && (memorabiliaSearchCriteria.ImageFilter == Domain.Constants.ImageFilter.None || (memorabiliaSearchCriteria.ImageFilter == Domain.Constants.ImageFilter.NoImages && !memorabilia.Images.Any()) || (memorabiliaSearchCriteria.ImageFilter == Domain.Constants.ImageFilter.Images && memorabilia.Images.Any()))
              && (!memorabiliaSearchCriteria.ItemTypeIds.Any() || memorabiliaSearchCriteria.ItemTypeIds.Contains(memorabilia.ItemTypeId))
              && (!memorabiliaSearchCriteria.LevelTypeIds.Any() || (memorabilia.LevelType != null && memorabiliaSearchCriteria.LevelTypeIds.Contains(memorabilia.LevelType.LevelTypeId)))
              && (!memorabiliaSearchCriteria.People.Any() || memorabilia.People.Any(person => memorabiliaSearchCriteria.PersonIds.Contains(person.PersonId)))
              && (!memorabiliaSearchCriteria.PurchaseTypeIds.Any() || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId.HasValue && memorabiliaSearchCriteria.PurchaseTypeIds.Contains(memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId.Value)))
              && (!memorabiliaSearchCriteria.PrivacyTypeIds.Any() || memorabiliaSearchCriteria.PrivacyTypeIds.Contains(memorabilia.PrivacyTypeId))
              && (!memorabiliaSearchCriteria.SizeIds.Any() || (memorabilia.Size != null && memorabiliaSearchCriteria.SizeIds.Contains(memorabilia.Size.SizeId)))
              && (!memorabiliaSearchCriteria.SportIds.Any() || memorabilia.Sports.Any(sport => memorabiliaSearchCriteria.SportIds.Contains(sport.SportId)))
              && (!memorabiliaSearchCriteria.SportLeagueLevelIds.Any() || memorabilia.Teams.Any(team => memorabiliaSearchCriteria.SportLeagueLevelIds.Contains(team.Team.Franchise.SportLeagueLevel.Id)))
              && (!memorabiliaSearchCriteria.Teams.Any() || memorabilia.Teams.Any(team => memorabiliaSearchCriteria.TeamIds.Contains(team.TeamId)))
            orderby memorabilia.CreateDate
            select new Domain.Entities.Memorabilia(memorabilia);

        return await query.ToPagedResult(pageInfo);
    }    

    public async Task<Domain.Entities.Memorabilia[]> GetAll(Dictionary<string, object> parameters)
    {
        _ = parameters.TryGetValue("HelmetTypeId", out object helmetTypeId);
        _ = parameters.TryGetValue("HelmetSizeId", out object helmetSizeId);
        _ = parameters.TryGetValue("HelmetFinishId", out object helmetFinishId);
        _ = parameters.TryGetValue("ItemTypeId", out object itemTypeId);
        _ = parameters.TryGetValue("TeamId", out object teamId);
        _ = parameters.TryGetValue("TeamYear", out object teamYear);
        _ = parameters.TryGetValue("UserId", out object userId);        

        return await Items.Where(memorabilia => (userId == null || memorabilia.UserId == (int)userId)
                                                 && (teamId == null || memorabilia.Teams.Any(team => team.TeamId == (int)teamId))
                                                 && (helmetTypeId == null || (memorabilia.Helmet != null && memorabilia.Helmet.HelmetTypeId == (int)helmetTypeId))
                                                 && (helmetFinishId == null || (memorabilia.Helmet != null && memorabilia.Helmet.HelmetFinishId == (int)helmetFinishId))
                                                 && (helmetSizeId == null || (memorabilia.Size != null && memorabilia.Size.SizeId == (int)helmetSizeId))
                                                )
                          .ToArrayAsync();
    }

    public async Task<PagedResult<Domain.Entities.Memorabilia>> GetAllByCollection(
        int collectionId,
        PageInfo pageInfo,
        MemorabiliaSearchCriteria memorabiliaSearchCriteria = null)
    {
        var query =
            from memorabilia in Context.Memorabilia
            join collectionMemorabilia in Context.CollectionMemorabilia on memorabilia.Id equals collectionMemorabilia.MemorabiliaId
            where collectionMemorabilia.CollectionId == collectionId
              && (!memorabiliaSearchCriteria.AcquiredDateBegin.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.AcquiredDate >= memorabiliaSearchCriteria.AcquiredDateBegin))
              && (!memorabiliaSearchCriteria.AcquiredDateEnd.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.AcquiredDate <= memorabiliaSearchCriteria.AcquiredDateEnd))
              && (!memorabiliaSearchCriteria.AcquisitionTypeIds.Any() || (memorabilia.MemorabiliaAcquisition != null && memorabiliaSearchCriteria.AcquisitionTypeIds.Contains(memorabilia.MemorabiliaAcquisition.Acquisition.AcquisitionTypeId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateBegin.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.AcquiredDate >= memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateBegin.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateEnd.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.AcquiredDate <= memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateEnd.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquisitionTypeIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.AcquisitionTypeIds.Contains(autograph.Acquisition.AcquisitionTypeId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Domain.Constants.AuthenticationFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Domain.Constants.AuthenticationFilter.NotAuthenticated && memorabilia.Autographs.Any(autograph => !autograph.Authentications.Any())) || (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Domain.Constants.AuthenticationFilter.Authenticated && memorabilia.Autographs.Any(autograph => autograph.Authentications.Any())))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.ColorIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.ColorIds.Contains(autograph.ColorId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.ConditionIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.ConditionIds.Contains(autograph.ConditionId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.CostLow.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.Cost >= memorabiliaSearchCriteria.AutographSearchCriteria.CostLow.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.CostHigh.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.Cost <= memorabiliaSearchCriteria.AutographSearchCriteria.CostHigh.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueLow.HasValue || memorabilia.Autographs.Any(autograph => autograph.EstimatedValue >= memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueLow.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueHigh.HasValue || memorabilia.Autographs.Any(autograph => autograph.EstimatedValue <= memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueHigh.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.FranchiseIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.Team.FranchiseId).Any(franchiseId => memorabiliaSearchCriteria.AutographSearchCriteria.FranchiseIds.Contains(franchiseId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.Grade.HasValue || memorabilia.Autographs.Any(autograph => autograph.Grade == memorabiliaSearchCriteria.AutographSearchCriteria.Grade.Value))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Domain.Constants.ImageFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Domain.Constants.ImageFilter.NoImages && memorabilia.Autographs.Any(autograph => !autograph.Images.Any())) || (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Domain.Constants.ImageFilter.Images && memorabilia.Autographs.Any(autograph => autograph.Images.Any())))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Domain.Constants.InscriptionFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Domain.Constants.InscriptionFilter.NoInscription && memorabilia.Autographs.Any(autograph => !autograph.Inscriptions.Any())) || (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Domain.Constants.InscriptionFilter.Inscription && memorabilia.Autographs.Any(autograph => autograph.Inscriptions.Any())))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.People.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.PersonIds.Contains(autograph.PersonId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Domain.Constants.PersonalizationFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Domain.Constants.PersonalizationFilter.NotPersonalized && memorabilia.Autographs.Any(autograph => autograph.Personalization == null)) || (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Domain.Constants.PersonalizationFilter.Personalized && memorabilia.Autographs.Any(autograph => autograph.Personalization != null)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SportIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Sports.Select(sport => sport.SportId).Any(sportId => memorabiliaSearchCriteria.AutographSearchCriteria.SportIds.Contains(sportId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SportLeagueLevelIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.Team.Franchise.SportLeagueLevel.Id).Any(sportLeagueLevelId => memorabiliaSearchCriteria.AutographSearchCriteria.SportLeagueLevelIds.Contains(sportLeagueLevelId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SpotIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.SpotIds.Contains(autograph.Spot.SpotId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.Teams.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.TeamId).Any(teamId => memorabiliaSearchCriteria.AutographSearchCriteria.TeamIds.Contains(teamId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.WritingInstrumentIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.WritingInstrumentIds.Contains(autograph.WritingInstrumentId)))
              && (!memorabiliaSearchCriteria.BrandIds.Any() || (memorabilia.Brand != null && memorabiliaSearchCriteria.BrandIds.Contains(memorabilia.Brand.BrandId)))
              && (!memorabiliaSearchCriteria.ConditionIds.Any() || (memorabilia.ConditionId.HasValue && memorabiliaSearchCriteria.ConditionIds.Contains(memorabilia.ConditionId.Value)))
              && (!memorabiliaSearchCriteria.CostLow.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.Cost >= memorabiliaSearchCriteria.CostLow.Value))
              && (!memorabiliaSearchCriteria.CostHigh.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.Cost <= memorabiliaSearchCriteria.CostHigh.Value))
              && (!memorabiliaSearchCriteria.EstimatedValueLow.HasValue || memorabilia.EstimatedValue >= memorabiliaSearchCriteria.EstimatedValueLow.Value)
              && (!memorabiliaSearchCriteria.EstimatedValueHigh.HasValue || memorabilia.EstimatedValue <= memorabiliaSearchCriteria.EstimatedValueHigh.Value)
              && (!memorabiliaSearchCriteria.FranchiseIds.Any() || memorabilia.Teams.Select(team => team.Team.Franchise.Id).Any(franchiseId => memorabiliaSearchCriteria.FranchiseIds.Contains(franchiseId)))
              && (!memorabiliaSearchCriteria.GameStyleTypeIds.Any() || (memorabilia.Game != null && memorabiliaSearchCriteria.GameStyleTypeIds.Contains(memorabilia.Game.GameStyleTypeId)))
              && (memorabiliaSearchCriteria.ImageFilter == Domain.Constants.ImageFilter.None || (memorabiliaSearchCriteria.ImageFilter == Domain.Constants.ImageFilter.NoImages && !memorabilia.Images.Any()) || (memorabiliaSearchCriteria.ImageFilter == Domain.Constants.ImageFilter.Images && memorabilia.Images.Any()))
              && (!memorabiliaSearchCriteria.ItemTypeIds.Any() || memorabiliaSearchCriteria.ItemTypeIds.Contains(memorabilia.ItemTypeId))
              && (!memorabiliaSearchCriteria.LevelTypeIds.Any() || (memorabilia.LevelType != null && memorabiliaSearchCriteria.LevelTypeIds.Contains(memorabilia.LevelType.LevelTypeId)))
              && (!memorabiliaSearchCriteria.People.Any() || memorabilia.People.Any(person => memorabiliaSearchCriteria.PersonIds.Contains(person.PersonId)))
              && (!memorabiliaSearchCriteria.PurchaseTypeIds.Any() || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId.HasValue && memorabiliaSearchCriteria.PurchaseTypeIds.Contains(memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId.Value)))
              && (!memorabiliaSearchCriteria.PrivacyTypeIds.Any() || memorabiliaSearchCriteria.PrivacyTypeIds.Contains(memorabilia.PrivacyTypeId))
              && (!memorabiliaSearchCriteria.SizeIds.Any() || (memorabilia.Size != null && memorabiliaSearchCriteria.SizeIds.Contains(memorabilia.Size.SizeId)))
              && (!memorabiliaSearchCriteria.SportIds.Any() || memorabilia.Sports.Any(sport => memorabiliaSearchCriteria.SportIds.Contains(sport.SportId)))
              && (!memorabiliaSearchCriteria.SportLeagueLevelIds.Any() || memorabilia.Teams.Any(team => memorabiliaSearchCriteria.SportLeagueLevelIds.Contains(team.Team.Franchise.SportLeagueLevel.Id)))
              && (!memorabiliaSearchCriteria.Teams.Any() || memorabilia.Teams.Any(team => memorabiliaSearchCriteria.TeamIds.Contains(team.TeamId)))
            orderby memorabilia.CreateDate
            select new Domain.Entities.Memorabilia(memorabilia);

        return await query.ToPagedResult(pageInfo);
    }

    public async Task<IEnumerable<Domain.Entities.Memorabilia>> GetAllUnsigned(int userId)
    {
        return await Memorabilia.Where(memorabilia => memorabilia.UserId == userId && !memorabilia.Autographs.Any()).ToListAsync();
    }

    public int[] GetBrandIds(int userId)
    {
        return Items.Where(memorabilia => memorabilia.UserId == userId && memorabilia.Brand != null)
                    .Select(memorabilia => memorabilia.Brand.BrandId)
                    .ToArray();
    }

    public int[] GetConditionIds(int userId)
    {
        return Items.Where(memorabilia => memorabilia.UserId == userId && memorabilia.ConditionId.HasValue)
                    .Select(memorabilia => memorabilia.ConditionId.Value)
                    .ToArray();
    }

    public decimal GetCostTotal(int userId)
    {
        return Items.Where(memorabilia => memorabilia.UserId == userId && memorabilia.MemorabiliaAcquisition.Acquisition != null)
                    .Sum(memorabilia => memorabilia.MemorabiliaAcquisition.Acquisition.Cost ?? 0);
    }

    public decimal GetEstimatedValueTotal(int userId)
    {
        return Items.Where(memorabilia => memorabilia.UserId == userId)
                    .Sum(memorabilia => memorabilia.EstimatedValue ?? 0);
    }

    public int[] GetFranchiseIds(int userId)
    {
        return Items.Where(memorabilia => memorabilia.UserId == userId && memorabilia.Teams.Any())
                    .SelectMany(memorabilia => memorabilia.Teams.Select(team => team.Team.Franchise.Id))
                    .ToArray();
    }

    public int[] GetPurchaseTypeIds(int userId)
    {
        return Items.Where(memorabilia => memorabilia.UserId == userId && memorabilia.MemorabiliaAcquisition.Acquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId.HasValue)
                    .Select(memorabilia => memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId.Value)
                    .ToArray();
    }

    public int[] GetItemTypeIds(int userId)
    {
        return Items.Where(memorabilia => memorabilia.UserId == userId)
                    .Select(memorabilia => memorabilia.ItemTypeId)
                    .ToArray();
    }

    public int[] GetSizeIds(int userId)
    {
        return Items.Where(memorabilia => memorabilia.UserId == userId && memorabilia.Size != null)
                    .Select(memorabilia => memorabilia.Size.SizeId)
                    .ToArray();
    }

    public int[] GetSportIds(int userId)
    {
        return Items.Where(memorabilia => memorabilia.UserId == userId && memorabilia.Sports.Any())
                    .SelectMany(memorabilia => memorabilia.Sports.Select(sport => sport.SportId))
                    .ToArray();
    }

    public int[] GetSportLeagueLevelIds(int userId)
    {
        return Items.Where(memorabilia => memorabilia.UserId == userId && memorabilia.Teams.Any())
                    .SelectMany(memorabilia => memorabilia.Teams.Select(team => team.Team.Franchise.SportLeagueLevel.Id))
                    .ToArray();
    }
}
