using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class DivisionRepository : BaseRepository<Domain.Entities.Division>, IDivisionRepository
    {
        private readonly Context _context;

        public DivisionRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.Division> Division => _context.Set<Domain.Entities.Division>();

        public async Task Add(Domain.Entities.Division division, CancellationToken cancellationToken = default)
        {
            _context.Add(division);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.Division division, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Division>().Remove(division);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.Division> Get(int id)
        {
            return await Division.SingleOrDefaultAsync(division => division.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.Division>> GetAll()
        {
            return (await Division.ToListAsync().ConfigureAwait(false)).OrderBy(Division => Division.Name);
        }

        public async Task Update(Domain.Entities.Division division, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Division>().Update(division);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
