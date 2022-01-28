using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class JerseyLevelTypeRepository : BaseRepository<Domain.Entities.JerseyLevelType>, IJerseyLevelTypeRepository
    {
        private readonly Context _context;

        public JerseyLevelTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.JerseyLevelType> JerseyLevelType => _context.Set<Domain.Entities.JerseyLevelType>();

        public async Task Add(Domain.Entities.JerseyLevelType jerseyLevelType, CancellationToken cancellationToken = default)
        {
            _context.Add(jerseyLevelType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.JerseyLevelType jerseyLevelType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.JerseyLevelType>().Remove(jerseyLevelType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.JerseyLevelType> Get(int id)
        {
            return await JerseyLevelType.SingleOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.JerseyLevelType>> GetAll()
        {
            return await JerseyLevelType.ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.JerseyLevelType jerseyLevelType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.JerseyLevelType>().Update(jerseyLevelType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
