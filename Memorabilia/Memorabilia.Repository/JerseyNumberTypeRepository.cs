using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class JerseyNumberTypeRepository : BaseRepository<Domain.Entities.JerseyNumberType>, IJerseyNumberTypeRepository
    {
        private readonly Context _context;

        public JerseyNumberTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.JerseyNumberType> JerseyNumberType => _context.Set<Domain.Entities.JerseyNumberType>();

        public async Task Add(Domain.Entities.JerseyNumberType jerseyNumberType, CancellationToken cancellationToken = default)
        {
            _context.Add(jerseyNumberType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.JerseyNumberType jerseyNumberType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.JerseyNumberType>().Remove(jerseyNumberType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.JerseyNumberType> Get(int id)
        {
            return await JerseyNumberType.SingleOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.JerseyNumberType>> GetAll()
        {
            return await JerseyNumberType.ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.JerseyNumberType jerseyNumberType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.JerseyNumberType>().Update(jerseyNumberType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
