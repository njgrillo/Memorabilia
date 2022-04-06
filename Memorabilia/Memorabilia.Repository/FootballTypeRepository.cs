using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class FootballTypeRepository : BaseRepository<FootballType>, IFootballTypeRepository
    {
        private readonly DomainContext _context;

        public FootballTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<FootballType> FootballType => _context.Set<FootballType>();

        public async Task Add(FootballType footballType, CancellationToken cancellationToken = default)
        {
            _context.Add(footballType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(FootballType footballType, CancellationToken cancellationToken = default)
        {
            _context.Set<FootballType>().Remove(footballType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<FootballType> Get(int id)
        {
            return await FootballType.SingleOrDefaultAsync(footballType => footballType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<FootballType>> GetAll()
        {
            return (await FootballType.ToListAsync().ConfigureAwait(false)).OrderBy(footballType => footballType.Name);
        }

        public async Task Update(FootballType footballType, CancellationToken cancellationToken = default)
        {
            _context.Set<FootballType>().Update(footballType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
