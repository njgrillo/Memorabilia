using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class JerseyTypeRepository : BaseRepository<JerseyType>, IJerseyTypeRepository
    {
        private readonly DomainContext _context;

        public JerseyTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<JerseyType> JerseyType => _context.Set<JerseyType>();

        public async Task Add(JerseyType jerseyType, CancellationToken cancellationToken = default)
        {
            _context.Add(jerseyType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(JerseyType jerseyType, CancellationToken cancellationToken = default)
        {
            _context.Set<JerseyType>().Remove(jerseyType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<JerseyType> Get(int id)
        {
            return await JerseyType.SingleOrDefaultAsync(jerseyType => jerseyType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<JerseyType>> GetAll()
        {
            return (await JerseyType.ToListAsync().ConfigureAwait(false)).OrderBy(jerseyType => jerseyType.Name);
        }

        public async Task Update(JerseyType jerseyType, CancellationToken cancellationToken = default)
        {
            _context.Set<JerseyType>().Update(jerseyType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
