using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class GloveTypeRepository : BaseRepository<Domain.Entities.GloveType>, IGloveTypeRepository
    {
        private readonly Context _context;

        public GloveTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.GloveType> GloveType => _context.Set<Domain.Entities.GloveType>();

        public async Task Add(Domain.Entities.GloveType gloveType, CancellationToken cancellationToken = default)
        {
            _context.Add(gloveType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.GloveType gloveType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.GloveType>().Remove(gloveType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.GloveType> Get(int id)
        {
            return await GloveType.SingleOrDefaultAsync(gloveType => gloveType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.GloveType>> GetAll()
        {
            return (await GloveType.ToListAsync().ConfigureAwait(false)).OrderBy(gloveType => gloveType.Name);
        }

        public async Task Update(Domain.Entities.GloveType gloveType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.GloveType>().Update(gloveType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
