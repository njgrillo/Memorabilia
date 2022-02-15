using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class OccupationRepository : BaseRepository<Domain.Entities.Occupation>, IOccupationRepository
    {
        private readonly Context _context;

        public OccupationRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.Occupation> Occupation => _context.Set<Domain.Entities.Occupation>();

        public async Task Add(Domain.Entities.Occupation occupation, CancellationToken cancellationToken = default)
        {
            _context.Add(occupation);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.Occupation occupation, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Occupation>().Remove(occupation);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.Occupation> Get(int id)
        {
            return await Occupation.SingleOrDefaultAsync(occupation => occupation.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.Occupation>> GetAll()
        {
            return (await Occupation.ToListAsync().ConfigureAwait(false)).OrderBy(occupation => occupation.Name);
        }

        public async Task Update(Domain.Entities.Occupation occupation, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Occupation>().Update(occupation);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
