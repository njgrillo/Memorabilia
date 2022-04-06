using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class PurchaseTypeRepository : BaseRepository<PurchaseType>, IPurchaseTypeRepository
    {
        private readonly DomainContext _context;

        public PurchaseTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<PurchaseType> PurchaseType => _context.Set<PurchaseType>();

        public async Task Add(PurchaseType purchaseType, CancellationToken cancellationToken = default)
        {
            _context.Add(purchaseType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(PurchaseType purchaseType, CancellationToken cancellationToken = default)
        {
            _context.Set<PurchaseType>().Remove(purchaseType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<PurchaseType> Get(int id)
        {
            return await PurchaseType.SingleOrDefaultAsync(purchaseType => purchaseType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<PurchaseType>> GetAll()
        {
            return (await PurchaseType.ToListAsync().ConfigureAwait(false)).OrderBy(purchaseType => purchaseType.Name);
        }

        public async Task Update(PurchaseType purchaseType, CancellationToken cancellationToken = default)
        {
            _context.Set<PurchaseType>().Update(purchaseType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}