using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MagazineTypeRepository : BaseRepository<MagazineType>, IMagazineTypeRepository
    {
        private readonly DomainContext _context;

        public MagazineTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<MagazineType> MagazineType => _context.Set<MagazineType>();

        public async Task Add(MagazineType magazineType, CancellationToken cancellationToken = default)
        {
            _context.Add(magazineType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(MagazineType magazineType, CancellationToken cancellationToken = default)
        {
            _context.Set<MagazineType>().Remove(magazineType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<MagazineType> Get(int id)
        {
            return await MagazineType.SingleOrDefaultAsync(magazineType => magazineType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<MagazineType>> GetAll()
        {
            return (await MagazineType.ToListAsync().ConfigureAwait(false)).OrderBy(magazineType => magazineType.Name);
        }

        public async Task Update(MagazineType magazineType, CancellationToken cancellationToken = default)
        {
            _context.Set<MagazineType>().Update(magazineType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
