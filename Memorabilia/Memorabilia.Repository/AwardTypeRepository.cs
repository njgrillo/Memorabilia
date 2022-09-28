using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class AwardTypeRepository : BaseRepository<AwardType>, IAwardTypeRepository
    {
        private readonly DomainContext _context;

        public AwardTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<AwardType> AwardType => _context.Set<AwardType>();

        public async Task Add(AwardType awardType, CancellationToken cancellationToken = default)
        {
            _context.Add(awardType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(AwardType awardType, CancellationToken cancellationToken = default)
        {
            _context.Set<AwardType>().Remove(awardType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<AwardType> Get(int id)
        {
            return await AwardType.SingleOrDefaultAsync(awardType => awardType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<AwardType>> GetAll()
        {
            return (await AwardType.ToListAsync().ConfigureAwait(false)).OrderBy(awardType => awardType.Name);
        }

        public async Task Update(AwardType awardType, CancellationToken cancellationToken = default)
        {
            _context.Set<AwardType>().Update(awardType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
