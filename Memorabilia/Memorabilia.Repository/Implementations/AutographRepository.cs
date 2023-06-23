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

    public async Task<Entity.Autograph[]> GetAllBaseballTypes(int itemTypeId, 
                                                              int personId, 
                                                              int baseballTypeId,
                                                              int? teamId,
                                                              int? year,
                                                              int userId)
        => await Autograph.Where(autograph => autograph.Memorabilia.UserId == userId
                                           && autograph.PersonId == personId
                                           && autograph.Memorabilia.ItemTypeId == itemTypeId
                                           && autograph.Memorabilia.Baseball != null
                                           && autograph.Memorabilia.Baseball.BaseballTypeId == baseballTypeId
                                           && (teamId == null || autograph.Memorabilia.Teams.Any(team => team.TeamId == teamId.Value))
                                           && (year == null || (autograph.Memorabilia.Baseball != null && autograph.Memorabilia.Baseball.Year == year.Value))
                                )
                          .ToArrayAsync();

    public async Task<Entity.Autograph[]> GetAllCards(int itemTypeId,
                                                      int personId,
                                                      int brandId,
                                                      int? teamId,
                                                      int? year,
                                                      int userId)
        => await Autograph.Where(autograph => autograph.Memorabilia.UserId == userId
                                           && autograph.PersonId == personId
                                           && autograph.Memorabilia.ItemTypeId == itemTypeId
                                           && autograph.Memorabilia.Card != null
                                           && autograph.Memorabilia.Brand != null 
                                           && autograph.Memorabilia.Brand.BrandId == brandId
                                           && (teamId == null || autograph.Memorabilia.Teams.Any(team => team.TeamId == teamId.Value))
                                           && (year == null || autograph.Memorabilia.Card.Year == year.Value)
                                )
                          .ToArrayAsync();

    public async Task<Entity.Autograph[]> GetAllHallOfFamers(int itemTypeId,
                                                             int personId,
                                                             int sportLeagueLevelId,
                                                             int? year,
                                                             int userId)
        => await Autograph.Where(autograph => autograph.Memorabilia.UserId == userId
                                           && autograph.PersonId == personId
                                           && autograph.Memorabilia.ItemTypeId == itemTypeId
                                           && autograph.Person != null 
                                           && autograph.Person.HallOfFames.Any(hof => hof.SportLeagueLevelId == sportLeagueLevelId)
                                           && (year == null || autograph.Person.HallOfFames.Any(hof => hof.InductionYear == year.Value))
                                )
                          .ToArrayAsync();

    public async Task<Entity.Autograph[]> GetAllItemTypes(int itemTypeId,
                                                          int personId,
                                                          bool? multiSignedItem,
                                                          int userId)
        => await Autograph.Where(autograph => autograph.Memorabilia.UserId == userId
                                           && autograph.PersonId == personId
                                           && autograph.Memorabilia.ItemTypeId == itemTypeId
                                           && (!multiSignedItem.HasValue || (multiSignedItem.Value && autograph.Memorabilia.Autographs.Count > 1) || (!multiSignedItem.Value && autograph.Memorabilia.Autographs.Count == 1))
                                )
                          .ToArrayAsync();

    public async Task<Entity.Autograph[]> GetAllTeams(int itemTypeId,
                                                      int personId,
                                                      int teamId,
                                                      int? year,
                                                      int userId)
        => await Autograph.Where(autograph => autograph.Memorabilia.UserId == userId
                                           && autograph.PersonId == personId
                                           && autograph.Memorabilia.ItemTypeId == itemTypeId
                                           && autograph.Memorabilia.Teams.Any(team => team.TeamId == teamId)
                                           && (year == null || autograph.Memorabilia.Teams.Any(team => (team.Team.BeginYear != null && team.Team.BeginYear <= year.Value) && (team.Team.EndYear == null || team.Team.EndYear >= year.Value)))
                                )
                          .ToArrayAsync();

    public async Task<Entity.Autograph[]> GetAllWorldSeries(int itemTypeId,
                                                            int personId,
                                                            int teamId,
                                                            int? year,
                                                            int userId)
        => await Autograph.Where(autograph => autograph.Memorabilia.UserId == userId
                                           && autograph.PersonId == personId
                                           && autograph.Memorabilia.ItemTypeId == itemTypeId
                                           && autograph.Memorabilia.Teams.Any(team => team.TeamId == teamId)
                                           && (year == null || autograph.Memorabilia.Teams.Any(team => (team.Team.BeginYear != null && team.Team.BeginYear <= year.Value) && (team.Team.EndYear == null || team.Team.EndYear >= year.Value)))
                                )
                          .ToArrayAsync();

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
