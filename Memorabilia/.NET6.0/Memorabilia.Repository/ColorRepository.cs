using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;

namespace Memorabilia.Repository
{
    public class ColorRepository : BaseRepository<Domain.Entities.Color>, IColorRepository
    {
        private readonly Context _context;

        public ColorRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.Color> Color => _context.Set<Domain.Entities.Color>();

        public async Task Add(Domain.Entities.Color color, CancellationToken cancellationToken = default)
        {
            _context.Add(color);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.Color color, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Color>().Remove(color);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.Color> Get(int id)
        {
            return await Color.SingleOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.Color>> GetAll()
        {
            return await Color.ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.Color color, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Color>().Update(color);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
