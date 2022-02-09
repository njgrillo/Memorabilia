using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class JerseyStyleTypeRepository : BaseRepository<Domain.Entities.JerseyStyleType>, IJerseyStyleTypeRepository
    {
        private readonly Context _context;

        public JerseyStyleTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.JerseyStyleType> JerseyStyleType => _context.Set<Domain.Entities.JerseyStyleType>();

        public async Task Add(Domain.Entities.JerseyStyleType jerseyStyleType, CancellationToken cancellationToken = default)
        {
            _context.Add(jerseyStyleType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.JerseyStyleType jerseyStyleType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.JerseyStyleType>().Remove(jerseyStyleType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.JerseyStyleType> Get(int id)
        {
            return await JerseyStyleType.SingleOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.JerseyStyleType>> GetAll()
        {
            return await JerseyStyleType.ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.JerseyStyleType jerseyStyleType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.JerseyStyleType>().Update(jerseyStyleType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}