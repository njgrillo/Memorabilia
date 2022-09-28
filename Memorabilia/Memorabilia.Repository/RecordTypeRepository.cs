using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class RecordTypeRepository : BaseRepository<RecordType>, IRecordTypeRepository
    {
        private readonly DomainContext _context;

        public RecordTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<RecordType> RecordType => _context.Set<RecordType>();

        public async Task Add(RecordType recordType, CancellationToken cancellationToken = default)
        {
            _context.Add(recordType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(RecordType recordType, CancellationToken cancellationToken = default)
        {
            _context.Set<RecordType>().Remove(recordType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<RecordType> Get(int id)
        {
            return await RecordType.SingleOrDefaultAsync(RecordType => RecordType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<RecordType>> GetAll()
        {
            return (await RecordType.ToListAsync().ConfigureAwait(false)).OrderBy(RecordType => RecordType.Name);
        }

        public async Task Update(RecordType recordType, CancellationToken cancellationToken = default)
        {
            _context.Set<RecordType>().Update(recordType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
