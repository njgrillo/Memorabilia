using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class PewterRepository : BaseRepository<Domain.Entities.Pewter>, IPewterRepository
    {
        private readonly Context _context;

        public PewterRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.Pewter> Pewter => _context.Set<Domain.Entities.Pewter>()
                                                                     .Include(pewter => pewter.Team);

        public async Task Add(Domain.Entities.Pewter pewter, CancellationToken cancellationToken = default)
        {
            _context.Add(pewter);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.Pewter pewter, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Pewter>().Remove(pewter);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.Pewter> Get(int id)
        {
            return await Pewter.SingleOrDefaultAsync(pewter => pewter.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.Pewter>> GetAll()
        {
            return (await Pewter.ToListAsync()
                                .ConfigureAwait(false)).OrderBy(pewter => pewter.FranchiseName)
                                                       .ThenBy(pewter => pewter.Team.Name)
                                                       .ThenBy(pewter => pewter.SizeName)
                                                       .ThenBy(pewter => pewter.ImageTypeName);
        }

        public async Task Update(Domain.Entities.Pewter pewter, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Pewter>().Update(pewter);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
