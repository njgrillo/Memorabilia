using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class GameStyleTypeRepository : BaseRepository<GameStyleType>, IGameStyleTypeRepository
    {
        private readonly DomainContext _context;

        public GameStyleTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<GameStyleType> GameStyleType => _context.Set<GameStyleType>();

        public async Task Add(GameStyleType gameStyleType, CancellationToken cancellationToken = default)
        {
            _context.Add(gameStyleType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(GameStyleType gameStyleType, CancellationToken cancellationToken = default)
        {
            _context.Set<GameStyleType>().Remove(gameStyleType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<GameStyleType> Get(int id)
        {
            return await GameStyleType.SingleOrDefaultAsync(gameStyleType => gameStyleType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<GameStyleType>> GetAll()
        {
            return (await GameStyleType.ToListAsync().ConfigureAwait(false)).OrderBy(gameStyleType => gameStyleType.Name);
        }

        public async Task Update(GameStyleType gameStyleType, CancellationToken cancellationToken = default)
        {
            _context.Set<GameStyleType>().Update(gameStyleType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
