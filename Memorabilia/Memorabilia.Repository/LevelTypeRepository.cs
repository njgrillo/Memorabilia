using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class LevelTypeRepository : BaseRepository<LevelType>, ILevelTypeRepository
    {
        private readonly DomainContext _context;

        public LevelTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<LevelType> LevelType => _context.Set<LevelType>();

        public async Task Add(LevelType levelType, CancellationToken cancellationToken = default)
        {
            _context.Add(levelType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(LevelType levelType, CancellationToken cancellationToken = default)
        {
            _context.Set<LevelType>().Remove(levelType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<LevelType> Get(int id)
        {
            return await LevelType.SingleOrDefaultAsync(levelType => levelType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<LevelType>> GetAll()
        {
            return (await LevelType.ToListAsync()
                                   .ConfigureAwait(false)).OrderBy(levelType => levelType.Name);
        }

        public async Task Update(LevelType levelType, CancellationToken cancellationToken = default)
        {
            _context.Set<LevelType>().Update(levelType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
