using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class FootballTypeRepository : BaseRepository<Domain.Entities.FootballType>, IFootballTypeRepository
    {
        private readonly Context _context;

        public FootballTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.FootballType> FootballType => _context.Set<Domain.Entities.FootballType>();

        public async Task Add(Domain.Entities.FootballType footballType, CancellationToken cancellationToken = default)
        {
            _context.Add(footballType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.FootballType footballType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.FootballType>().Remove(footballType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.FootballType> Get(int id)
        {
            return await FootballType.SingleOrDefaultAsync(footballType => footballType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.FootballType>> GetAll()
        {
            return (await FootballType.ToListAsync().ConfigureAwait(false)).OrderBy(footballType => footballType.Name);
        }

        public async Task Update(Domain.Entities.FootballType footballType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.FootballType>().Update(footballType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
