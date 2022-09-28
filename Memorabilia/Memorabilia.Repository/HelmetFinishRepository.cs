using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class HelmetFinishRepository : BaseRepository<HelmetFinish>, IHelmetFinishRepository
    {
        private readonly DomainContext _context;

        public HelmetFinishRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<HelmetFinish> HelmetFinish => _context.Set<HelmetFinish>();

        public async Task Add(HelmetFinish helmetFinish, CancellationToken cancellationToken = default)
        {
            _context.Add(helmetFinish);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(HelmetFinish helmetFinish, CancellationToken cancellationToken = default)
        {
            _context.Set<HelmetFinish>().Remove(helmetFinish);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<HelmetFinish> Get(int id)
        {
            return await HelmetFinish.SingleOrDefaultAsync(helmetFinish => helmetFinish.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<HelmetFinish>> GetAll()
        {
            return (await HelmetFinish.ToListAsync().ConfigureAwait(false)).OrderBy(helmetFinish => helmetFinish.Name);
        }

        public async Task Update(HelmetFinish helmetFinish, CancellationToken cancellationToken = default)
        {
            _context.Set<HelmetFinish>().Update(helmetFinish);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
