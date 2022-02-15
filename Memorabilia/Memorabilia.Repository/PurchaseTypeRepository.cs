using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class PurchaseTypeRepository : BaseRepository<Domain.Entities.PurchaseType>, IPurchaseTypeRepository
    {
        private readonly Context _context;

        public PurchaseTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.PurchaseType> PurchaseType => _context.Set<Domain.Entities.PurchaseType>();

        public async Task Add(Domain.Entities.PurchaseType purchaseType, CancellationToken cancellationToken = default)
        {
            _context.Add(purchaseType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.PurchaseType purchaseType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.PurchaseType>().Remove(purchaseType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.PurchaseType> Get(int id)
        {
            return await PurchaseType.SingleOrDefaultAsync(purchaseType => purchaseType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.PurchaseType>> GetAll()
        {
            return (await PurchaseType.ToListAsync().ConfigureAwait(false)).OrderBy(purchaseType => purchaseType.Name);
        }

        public async Task Update(Domain.Entities.PurchaseType purchaseType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.PurchaseType>().Update(purchaseType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}