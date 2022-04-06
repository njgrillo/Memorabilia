using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class OrientationRepository : BaseRepository<Orientation>, IOrientationRepository
    {
        private readonly DomainContext _context;

        public OrientationRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Orientation> Orientation => _context.Set<Orientation>();

        public async Task Add(Orientation orientation, CancellationToken cancellationToken = default)
        {
            _context.Add(orientation);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Orientation orientation, CancellationToken cancellationToken = default)
        {
            _context.Set<Orientation>().Remove(orientation);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Orientation> Get(int id)
        {
            return await Orientation.SingleOrDefaultAsync(orientation => orientation.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Orientation>> GetAll()
        {
            return (await Orientation.ToListAsync().ConfigureAwait(false)).OrderBy(orientation => orientation.Name);
        }

        public async Task Update(Orientation orientation, CancellationToken cancellationToken = default)
        {
            _context.Set<Orientation>().Update(orientation);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
