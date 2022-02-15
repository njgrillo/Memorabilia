using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class GameStyleTypeRepository : BaseRepository<Domain.Entities.GameStyleType>, IGameStyleTypeRepository
    {
        private readonly Context _context;

        public GameStyleTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.GameStyleType> GameStyleType => _context.Set<Domain.Entities.GameStyleType>();

        public async Task Add(Domain.Entities.GameStyleType gameStyleType, CancellationToken cancellationToken = default)
        {
            _context.Add(gameStyleType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.GameStyleType gameStyleType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.GameStyleType>().Remove(gameStyleType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.GameStyleType> Get(int id)
        {
            return await GameStyleType.SingleOrDefaultAsync(gameStyleType => gameStyleType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.GameStyleType>> GetAll()
        {
            return (await GameStyleType.ToListAsync().ConfigureAwait(false)).OrderBy(gameStyleType => gameStyleType.Name);
        }

        public async Task Update(Domain.Entities.GameStyleType gameStyleType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.GameStyleType>().Update(gameStyleType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
