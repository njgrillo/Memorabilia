using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class AccomplishmentTypeRepository : BaseRepository<AccomplishmentType>, IAccomplishmentTypeRepository
    {
        private readonly DomainContext _context;

        public AccomplishmentTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<AccomplishmentType> AccomplishmentType => _context.Set<AccomplishmentType>();

        public async Task Add(AccomplishmentType accomplishmentType, CancellationToken cancellationToken = default)
        {
            _context.Add(accomplishmentType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(AccomplishmentType accomplishmentType, CancellationToken cancellationToken = default)
        {
            _context.Set<AccomplishmentType>().Remove(accomplishmentType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<AccomplishmentType> Get(int id)
        {
            return await AccomplishmentType.SingleOrDefaultAsync(accomplishmentType => accomplishmentType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<AccomplishmentType>> GetAll()
        {
            return (await AccomplishmentType.ToListAsync().ConfigureAwait(false)).OrderBy(accomplishmentType => accomplishmentType.Name);
        }

        public async Task Update(AccomplishmentType accomplishmentType, CancellationToken cancellationToken = default)
        {
            _context.Set<AccomplishmentType>().Update(accomplishmentType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}