using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class ChampionTypeRepository : BaseRepository<ChampionType>, IChampionTypeRepository
    {
        private readonly DomainContext _context;

        public ChampionTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<ChampionType> ChampionType => _context.Set<ChampionType>();

        public async Task Add(ChampionType championType, CancellationToken cancellationToken = default)
        {
            _context.Add(championType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(ChampionType championType, CancellationToken cancellationToken = default)
        {
            _context.Set<ChampionType>().Remove(championType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<ChampionType> Get(int id)
        {
            return await ChampionType.SingleOrDefaultAsync(championType => championType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ChampionType>> GetAll()
        {
            return (await ChampionType.ToListAsync().ConfigureAwait(false)).OrderBy(championType => championType.Name);
        }

        public async Task Update(ChampionType championType, CancellationToken cancellationToken = default)
        {
            _context.Set<ChampionType>().Update(championType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
