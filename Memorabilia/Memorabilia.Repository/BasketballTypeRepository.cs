using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class BasketballTypeRepository : BaseRepository<Domain.Entities.BasketballType>, IBasketballTypeRepository
    {
        private readonly Context _context;

        public BasketballTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.BasketballType> BasketballType => _context.Set<Domain.Entities.BasketballType>();

        public async Task Add(Domain.Entities.BasketballType basketballType, CancellationToken cancellationToken = default)
        {
            _context.Add(basketballType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.BasketballType basketballType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.BasketballType>().Remove(basketballType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.BasketballType> Get(int id)
        {
            return await BasketballType.SingleOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.BasketballType>> GetAll()
        {
            return await BasketballType.ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.BasketballType basketballType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.BasketballType>().Update(basketballType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
