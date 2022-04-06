using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class HelmetTypeRepository : BaseRepository<HelmetType>, IHelmetTypeRepository
    {
        private readonly DomainContext _context;

        public HelmetTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<HelmetType> HelmetType => _context.Set<HelmetType>();

        public async Task Add(HelmetType helmetType, CancellationToken cancellationToken = default)
        {
            _context.Add(helmetType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(HelmetType helmetType, CancellationToken cancellationToken = default)
        {
            _context.Set<HelmetType>().Remove(helmetType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<HelmetType> Get(int id)
        {
            return await HelmetType.SingleOrDefaultAsync(helmetType => helmetType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<HelmetType>> GetAll()
        {
            return (await HelmetType.ToListAsync().ConfigureAwait(false)).OrderBy(helmetType => helmetType.Name);
        }

        public async Task Update(HelmetType helmetType, CancellationToken cancellationToken = default)
        {
            _context.Set<HelmetType>().Update(helmetType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
