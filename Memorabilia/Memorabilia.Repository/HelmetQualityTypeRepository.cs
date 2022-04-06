using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class HelmetQualityTypeRepository : BaseRepository<HelmetQualityType>, IHelmetQualityTypeRepository
    {
        private readonly DomainContext _context;

        public HelmetQualityTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<HelmetQualityType> HelmetQualityType => _context.Set<HelmetQualityType>();

        public async Task Add(HelmetQualityType helmetQualityType, CancellationToken cancellationToken = default)
        {
            _context.Add(helmetQualityType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(HelmetQualityType helmetQualityType, CancellationToken cancellationToken = default)
        {
            _context.Set<HelmetQualityType>().Remove(helmetQualityType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<HelmetQualityType> Get(int id)
        {
            return await HelmetQualityType.SingleOrDefaultAsync(helmetQualityType => helmetQualityType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<HelmetQualityType>> GetAll()
        {
            return (await HelmetQualityType.ToListAsync().ConfigureAwait(false)).OrderBy(helmetQualityType => helmetQualityType.Name);
        }

        public async Task Update(HelmetQualityType helmetQualityType, CancellationToken cancellationToken = default)
        {
            _context.Set<HelmetQualityType>().Update(helmetQualityType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
