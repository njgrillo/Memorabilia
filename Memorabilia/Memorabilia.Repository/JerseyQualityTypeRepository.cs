using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class JerseyQualityTypeRepository : BaseRepository<Domain.Entities.JerseyQualityType>, IJerseyQualityTypeRepository
    {
        private readonly Context _context;

        public JerseyQualityTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.JerseyQualityType> JerseyQualityType => _context.Set<Domain.Entities.JerseyQualityType>();

        public async Task Add(Domain.Entities.JerseyQualityType jerseyQualityType, CancellationToken cancellationToken = default)
        {
            _context.Add(jerseyQualityType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.JerseyQualityType jerseyQualityType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.JerseyQualityType>().Remove(jerseyQualityType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.JerseyQualityType> Get(int id)
        {
            return await JerseyQualityType.SingleOrDefaultAsync(jerseyQualityType => jerseyQualityType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.JerseyQualityType>> GetAll()
        {
            return (await JerseyQualityType.ToListAsync().ConfigureAwait(false)).OrderBy(jerseyQualityType => jerseyQualityType.Name);
        }

        public async Task Update(Domain.Entities.JerseyQualityType jerseyQualityType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.JerseyQualityType>().Update(jerseyQualityType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
