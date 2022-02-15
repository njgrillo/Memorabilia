using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class PrivacyTypeRepository : BaseRepository<Domain.Entities.PrivacyType>, IPrivacyTypeRepository
    {
        private readonly Context _context;

        public PrivacyTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.PrivacyType> PrivacyType => _context.Set<Domain.Entities.PrivacyType>();

        public async Task Add(Domain.Entities.PrivacyType privacyType, CancellationToken cancellationToken = default)
        {
            _context.Add(privacyType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.PrivacyType privacyType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.PrivacyType>().Remove(privacyType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.PrivacyType> Get(int id)
        {
            return await PrivacyType.SingleOrDefaultAsync(privacyType => privacyType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.PrivacyType>> GetAll()
        {
            return (await PrivacyType.ToListAsync().ConfigureAwait(false)).OrderBy(privacyType => privacyType.Name);
        }

        public async Task Update(Domain.Entities.PrivacyType privacyType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.PrivacyType>().Update(privacyType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
