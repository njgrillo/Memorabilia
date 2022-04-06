using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class PrivacyTypeRepository : BaseRepository<PrivacyType>, IPrivacyTypeRepository
    {
        private readonly DomainContext _context;

        public PrivacyTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<PrivacyType> PrivacyType => _context.Set<PrivacyType>();

        public async Task Add(PrivacyType privacyType, CancellationToken cancellationToken = default)
        {
            _context.Add(privacyType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(PrivacyType privacyType, CancellationToken cancellationToken = default)
        {
            _context.Set<PrivacyType>().Remove(privacyType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<PrivacyType> Get(int id)
        {
            return await PrivacyType.SingleOrDefaultAsync(privacyType => privacyType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<PrivacyType>> GetAll()
        {
            return (await PrivacyType.ToListAsync().ConfigureAwait(false)).OrderBy(privacyType => privacyType.Name);
        }

        public async Task Update(PrivacyType privacyType, CancellationToken cancellationToken = default)
        {
            _context.Set<PrivacyType>().Update(privacyType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
