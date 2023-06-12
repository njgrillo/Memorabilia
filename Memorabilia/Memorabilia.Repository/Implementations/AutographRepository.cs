namespace Memorabilia.Repository.Implementations;

public class AutographRepository 
    : MemorabiliaRepository<Entity.Autograph>, IAutographRepository
{
    public AutographRepository(MemorabiliaContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<Entity.Autograph> Autograph 
        => Items.Include(autograph => autograph.Acquisition)
                .Include(autograph => autograph.Authentications)
                .Include(autograph => autograph.Images)
                .Include(autograph => autograph.Inscriptions)
                .Include(autograph => autograph.Memorabilia)
                .Include(autograph => autograph.Person)
                .Include(autograph => autograph.Personalization)
                .Include(autograph => autograph.Spot);

    public override async Task<Entity.Autograph> Get(int id)
        => await Autograph.SingleOrDefaultAsync(autograph => autograph.Id == id);

    public async Task<Entity.Autograph[]> GetAll(int? memorabiliaId = null, 
                                                            int? userId = null)
    {
        if (memorabiliaId.HasValue)
            return await Autograph.Where(autograph => autograph.MemorabiliaId == memorabiliaId)
                                  .ToArrayAsync();

        if (userId.HasValue)
            return await Autograph.Where(autograph => autograph.Memorabilia.UserId == userId)
                                  .ToArrayAsync();

        return await Autograph.ToArrayAsync();
    }

    public async Task<Entity.Autograph[]> GetAll(Dictionary<string, object> parameters)
    {
        _ = parameters.TryGetValue("UserId", out object userId);
        _ = parameters.TryGetValue("PersonId", out object personId);
        _ = parameters.TryGetValue("ItemTypeId", out object itemTypeId);
        _ = parameters.TryGetValue("BaseballTypeId", out object baseballTypeId);
        _ = parameters.TryGetValue("BaseballTypeTeamId", out object baseballTypeTeamId);
        _ = parameters.TryGetValue("BaseballTypeYear", out object baseballTypeYear);
        _ = parameters.TryGetValue("CardBrandId", out object cardBrandId);
        _ = parameters.TryGetValue("CardTeamId", out object cardTeamId);
        _ = parameters.TryGetValue("CardYear", out object cardYear);
        _ = parameters.TryGetValue("HallOfFameSportLeagueLevelId", out object hallOfFameSportLeagueLevelId);
        _ = parameters.TryGetValue("HallOfFameItemTypeId", out object hallOfFameItemTypeId);
        _ = parameters.TryGetValue("HallOfFameYear", out object hallOfFameYear);
        _ = parameters.TryGetValue("MultiSignedItem", out object multiSignedItem);
        _ = parameters.TryGetValue("TeamId", out object teamId);
        _ = parameters.TryGetValue("TeamYear", out object teamYear);
        _ = parameters.TryGetValue("WorldSeriesTeamId", out object worldSeriesTeamId);
        _ = parameters.TryGetValue("WorldSeriesItemTypeId", out object worldSeriesItemTypeId);
        _ = parameters.TryGetValue("WorldSeriesYear", out object worldSeriesYear);

        return await Autograph.Where(autograph => (userId == null || autograph.Memorabilia.UserId == (int)userId)
                                               && (personId == null || autograph.PersonId == (int)personId)
                                               && (itemTypeId == null || autograph.Memorabilia.ItemTypeId == (int)itemTypeId)
                                               && (baseballTypeId == null || (autograph.Memorabilia.Baseball != null && autograph.Memorabilia.Baseball.BaseballTypeId == (int)baseballTypeId))
                                               && (baseballTypeTeamId == null || autograph.Memorabilia.Teams.Any(team => team.TeamId == (int)baseballTypeTeamId))
                                               && (baseballTypeYear == null || (autograph.Memorabilia.Baseball != null && autograph.Memorabilia.Baseball.Year == (int)baseballTypeYear))
                                               && (cardBrandId == null || (autograph.Memorabilia.Brand != null && autograph.Memorabilia.Brand.BrandId == (int)cardBrandId))
                                               && (cardTeamId == null || autograph.Memorabilia.Teams.Any(team => team.TeamId == (int)cardTeamId))
                                               && (cardYear == null || (autograph.Memorabilia.Card != null && autograph.Memorabilia.Card.Year == (int)cardYear))
                                               && (hallOfFameSportLeagueLevelId == null || (autograph.Person != null && autograph.Person.HallOfFames.Any(hof => hof.SportLeagueLevelId == (int)hallOfFameSportLeagueLevelId)))
                                               && (hallOfFameItemTypeId == null || autograph.Memorabilia.ItemTypeId == (int)hallOfFameItemTypeId)
                                               && (hallOfFameYear == null || (autograph.Person != null && autograph.Person.HallOfFames.Any(hof => hof.InductionYear == (int)hallOfFameYear)))
                                               && (multiSignedItem == null || ((bool)multiSignedItem && autograph.Memorabilia.Autographs.Count > 1) || (!(bool)multiSignedItem && autograph.Memorabilia.Autographs.Count == 1))
                                               && (teamId == null || autograph.Memorabilia.Teams.Any(team => team.TeamId == (int)teamId))
                                               && (teamYear == null || autograph.Memorabilia.Teams.Any(team => (team.Team.BeginYear != null && team.Team.BeginYear <= (int)teamYear) && (team.Team.EndYear == null || team.Team.EndYear >= (int)teamYear)))
                                               && (worldSeriesTeamId == null || autograph.Memorabilia.Teams.Any(team => team.TeamId == (int)worldSeriesTeamId))
                                               && (worldSeriesItemTypeId == null || autograph.Memorabilia.ItemTypeId == (int)worldSeriesItemTypeId)
                                               && (worldSeriesYear == null || autograph.Memorabilia.Teams.Any(team => (team.Team.BeginYear != null && team.Team.BeginYear <= (int)worldSeriesYear) && (team.Team.EndYear == null || team.Team.EndYear >= (int)worldSeriesYear))))
                              .ToArrayAsync();
    }

    public int[] GetAcquisitionTypeIds(int userId)
        => Items.Where(autograph => autograph.Memorabilia.UserId == userId && autograph.Acquisition != null)
                .Select(autograph => autograph.Acquisition.AcquisitionTypeId)
                .ToArray();

    public int[] GetColorIds(int userId)
        => Items.Where(autograph => autograph.Memorabilia.UserId == userId)
                .Select(autograph => autograph.ColorId)
                .ToArray();

    public int[] GetConditionIds(int userId)
        => Items.Where(autograph => autograph.Memorabilia.UserId == userId)
                .Select(autograph => autograph.ConditionId)
                .ToArray();

    public decimal GetCostTotal(int userId)
        => Items.Where(autograph => autograph.Memorabilia.UserId == userId && autograph.Acquisition != null)
                .Sum(autograph => autograph.Acquisition.Cost ?? 0);

    public decimal GetEstimatedValueTotal(int userId)
        => Items.Where(autograph => autograph.Memorabilia.UserId == userId)
                .Sum(autograph => autograph.EstimatedValue ?? 0);

    public int[] GetSpotIds(int userId)
        => Items.Where(autograph => autograph.Memorabilia.UserId == userId && autograph.Spot != null)
                .Select(autograph => autograph.Spot.SpotId)
                .ToArray();

    public int[] GetWritingInstrumentIds(int userId)
        => Items.Where(autograph => autograph.Memorabilia.UserId == userId)
                .Select(autograph => autograph.WritingInstrumentId)
                .ToArray();
}
