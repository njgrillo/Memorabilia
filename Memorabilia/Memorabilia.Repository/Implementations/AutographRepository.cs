using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class AutographRepository : MemorabiliaRepository<Autograph>, IAutographRepository
{
    public AutographRepository(MemorabiliaContext context) : base(context) { }

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
}
