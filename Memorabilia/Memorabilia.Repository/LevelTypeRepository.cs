using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class LevelTypeRepository : BaseRepository<Domain.Entities.LevelType>, ILevelTypeRepository
    {
        private readonly Context _context;

        public LevelTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.LevelType> LevelType => _context.Set<Domain.Entities.LevelType>();

        public async Task Add(Domain.Entities.LevelType levelType, CancellationToken cancellationToken = default)
        {
            _context.Add(levelType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.LevelType levelType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.LevelType>().Remove(levelType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.LevelType> Get(int id)
        {
            return await LevelType.SingleOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.LevelType>> GetAll()
        {
            return await LevelType.ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.LevelType levelType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.LevelType>().Update(levelType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
