using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;

namespace Memorabilia.Repository
{
    public class JerseyTypeRepository : BaseRepository<Domain.Entities.JerseyType>, IJerseyTypeRepository
    {
        private readonly Context _context;

        public JerseyTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.JerseyType> JerseyType => _context.Set<Domain.Entities.JerseyType>();

        public async Task Add(Domain.Entities.JerseyType jerseyType, CancellationToken cancellationToken = default)
        {
            _context.Add(jerseyType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.JerseyType jerseyType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.JerseyType>().Remove(jerseyType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.JerseyType> Get(int id)
        {
            return await JerseyType.SingleOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.JerseyType>> GetAll()
        {
            return await JerseyType.ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.JerseyType jerseyType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.JerseyType>().Update(jerseyType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
