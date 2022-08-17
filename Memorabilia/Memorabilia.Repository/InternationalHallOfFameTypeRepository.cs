using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class InternationalHallOfFameTypeRepository : BaseRepository<InternationalHallOfFameType>, IInternationalHallOfFameTypeRepository
    {
        private readonly DomainContext _context;

        public InternationalHallOfFameTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<InternationalHallOfFameType> InternationalHallOfFameType => _context.Set<InternationalHallOfFameType>();

        public async Task Add(InternationalHallOfFameType internationalHallOfFameType, CancellationToken cancellationToken = default)
        {
            _context.Add(internationalHallOfFameType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(InternationalHallOfFameType internationalHallOfFameType, CancellationToken cancellationToken = default)
        {
            _context.Set<InternationalHallOfFameType>().Remove(internationalHallOfFameType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<InternationalHallOfFameType> Get(int id)
        {
            return await InternationalHallOfFameType.SingleOrDefaultAsync(internationalHallOfFameType => internationalHallOfFameType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<InternationalHallOfFameType>> GetAll()
        {
            return (await InternationalHallOfFameType.ToListAsync().ConfigureAwait(false)).OrderBy(internationalHallOfFameType => internationalHallOfFameType.Name);
        }

        public async Task Update(InternationalHallOfFameType internationalHallOfFameType, CancellationToken cancellationToken = default)
        {
            _context.Set<InternationalHallOfFameType>().Update(internationalHallOfFameType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
