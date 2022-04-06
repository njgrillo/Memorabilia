using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class OccupationRepository : BaseRepository<Occupation>, IOccupationRepository
    {
        private readonly DomainContext _context;

        public OccupationRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Occupation> Occupation => _context.Set<Occupation>();

        public async Task Add(Occupation occupation, CancellationToken cancellationToken = default)
        {
            _context.Add(occupation);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Occupation occupation, CancellationToken cancellationToken = default)
        {
            _context.Set<Occupation>().Remove(occupation);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Occupation> Get(int id)
        {
            return await Occupation.SingleOrDefaultAsync(occupation => occupation.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Occupation>> GetAll()
        {
            return (await Occupation.ToListAsync().ConfigureAwait(false)).OrderBy(occupation => occupation.Name);
        }

        public async Task Update(Occupation occupation, CancellationToken cancellationToken = default)
        {
            _context.Set<Occupation>().Update(occupation);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
