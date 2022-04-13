using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class SportServiceRepository : BaseRepository<SportService>, ISportServiceRepository
    {
        private readonly DomainContext _context;

        public SportServiceRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<SportService> SportService => _context.Set<SportService>();

        public async Task Add(SportService sportService, CancellationToken cancellationToken = default)
        {
            _context.Add(sportService);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(SportService sportService, CancellationToken cancellationToken = default)
        {
            _context.Set<SportService>().Remove(sportService);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<SportService> Get(int personId)
        {
            return await SportService.SingleOrDefaultAsync(sportService => sportService.PersonId == personId).ConfigureAwait(false);
        }

        public async Task<IEnumerable<SportService>> GetAll()
        {
            return await SportService.ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(SportService sportService, CancellationToken cancellationToken = default)
        {
            _context.Set<SportService>().Update(sportService);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
