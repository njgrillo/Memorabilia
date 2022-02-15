using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class HelmetQualityTypeRepository : BaseRepository<Domain.Entities.HelmetQualityType>, IHelmetQualityTypeRepository
    {
        private readonly Context _context;

        public HelmetQualityTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.HelmetQualityType> HelmetQualityType => _context.Set<Domain.Entities.HelmetQualityType>();

        public async Task Add(Domain.Entities.HelmetQualityType helmetQualityType, CancellationToken cancellationToken = default)
        {
            _context.Add(helmetQualityType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.HelmetQualityType helmetQualityType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.HelmetQualityType>().Remove(helmetQualityType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.HelmetQualityType> Get(int id)
        {
            return await HelmetQualityType.SingleOrDefaultAsync(helmetQualityType => helmetQualityType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.HelmetQualityType>> GetAll()
        {
            return (await HelmetQualityType.ToListAsync().ConfigureAwait(false)).OrderBy(helmetQualityType => helmetQualityType.Name);
        }

        public async Task Update(Domain.Entities.HelmetQualityType helmetQualityType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.HelmetQualityType>().Update(helmetQualityType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
