using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MagazineTypeRepository : BaseRepository<Domain.Entities.MagazineType>, IMagazineTypeRepository
    {
        private readonly Context _context;

        public MagazineTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.MagazineType> MagazineType => _context.Set<Domain.Entities.MagazineType>();

        public async Task Add(Domain.Entities.MagazineType magazineType, CancellationToken cancellationToken = default)
        {
            _context.Add(magazineType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.MagazineType magazineType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MagazineType>().Remove(magazineType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.MagazineType> Get(int id)
        {
            return await MagazineType.SingleOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.MagazineType>> GetAll()
        {
            return await MagazineType.ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.MagazineType magazineType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MagazineType>().Update(magazineType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
