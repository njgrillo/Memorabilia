using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class BaseballTypeRepository : BaseRepository<Domain.Entities.BaseballType>, IBaseballTypeRepository
    {
        private readonly Context _context;

        public BaseballTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.BaseballType> BaseballType => _context.Set<Domain.Entities.BaseballType>();

        public async Task Add(Domain.Entities.BaseballType baseballType, CancellationToken cancellationToken = default)
        {
            _context.Add(baseballType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.BaseballType baseballType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.BaseballType>().Remove(baseballType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.BaseballType> Get(int id)
        {
            return await BaseballType.SingleOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.BaseballType>> GetAll()
        {
            return await BaseballType.ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.BaseballType baseballType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.BaseballType>().Update(baseballType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
