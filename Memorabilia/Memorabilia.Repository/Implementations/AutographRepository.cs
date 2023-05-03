using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class AutographRepository : MemorabiliaRepository<Autograph>, IAutographRepository
{
    public AutographRepository(MemorabiliaContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

    private IQueryable<Autograph> Autograph => Items.Include(autograph => autograph.Acquisition)
                                                    .Include(autograph => autograph.Authentications)
                                                    .Include(autograph => autograph.Images)
                                                    .Include(autograph => autograph.Inscriptions)
                                                    .Include(autograph => autograph.Memorabilia)
                                                    .Include(autograph => autograph.Person)
                                                    .Include(autograph => autograph.Personalization)
                                                    .Include(autograph => autograph.Spot);

    public override async Task<Autograph> Get(int id)
    {
        return await Autograph.SingleOrDefaultAsync(autograph => autograph.Id == id);
    }

    public async Task<IEnumerable<Autograph>> GetAll(int? memorabiliaId = null, int? userId = null)
    {
        if (memorabiliaId.HasValue)
            return await Autograph.Where(autograph => autograph.MemorabiliaId == memorabiliaId).ToListAsync();

        if (userId.HasValue)
            return await Autograph.Where(autograph => autograph.Memorabilia.UserId == userId).ToListAsync();

        return await Autograph.ToListAsync();
    }

    public int[] GetAcquisitionTypeIds(int userId)
    {
        return Items.Where(autograph => autograph.Memorabilia.UserId == userId && autograph.Acquisition != null)
                    .Select(autograph => autograph.Acquisition.AcquisitionTypeId)
                    .ToArray();
    }

    public int[] GetColorIds(int userId)
    {
        return Items.Where(autograph => autograph.Memorabilia.UserId == userId)
                    .Select(autograph => autograph.ColorId)
                    .ToArray();
    }

    public int[] GetConditionIds(int userId)
    {
        return Items.Where(autograph => autograph.Memorabilia.UserId == userId)
                    .Select(autograph => autograph.ConditionId)
                    .ToArray();
    }

    public decimal GetCostTotal(int userId)
    {
        return Items.Where(autograph => autograph.Memorabilia.UserId == userId && autograph.Acquisition != null)
                    .Sum(autograph => autograph.Acquisition.Cost ?? 0);
    }

    public decimal GetEstimatedValueTotal(int userId)
    {
        return Items.Where(autograph => autograph.Memorabilia.UserId == userId)
                    .Sum(autograph => autograph.EstimatedValue ?? 0);
    }

    public int[] GetSpotIds(int userId)
    {
        return Items.Where(autograph => autograph.Memorabilia.UserId == userId && autograph.Spot != null)
                    .Select(autograph => autograph.Spot.SpotId)
                    .ToArray();
    }

    public int[] GetWritingInstrumentIds(int userId)
    {
        return Items.Where(autograph => autograph.Memorabilia.UserId == userId)
                    .Select(autograph => autograph.WritingInstrumentId)
                    .ToArray();
    }
}
