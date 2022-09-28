using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class WritingInstrumentRepository : BaseRepository<WritingInstrument>, IWritingInstrumentRepository
    {
        private readonly DomainContext _context;

        public WritingInstrumentRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<WritingInstrument> WritingInstrument => _context.Set<WritingInstrument>();

        public async Task Add(WritingInstrument writingInstrument, CancellationToken cancellationToken = default)
        {
            _context.Add(writingInstrument);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(WritingInstrument writingInstrument, CancellationToken cancellationToken = default)
        {
            _context.Set<WritingInstrument>().Remove(writingInstrument);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<WritingInstrument> Get(int id)
        {
            return await WritingInstrument.SingleOrDefaultAsync(writingInstrument => writingInstrument.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<WritingInstrument>> GetAll()
        {
            return (await WritingInstrument.ToListAsync().ConfigureAwait(false)).OrderBy(writingInstrument => writingInstrument.Name);
        }

        public async Task Update(WritingInstrument writingInstrument, CancellationToken cancellationToken = default)
        {
            _context.Set<WritingInstrument>().Update(writingInstrument);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
