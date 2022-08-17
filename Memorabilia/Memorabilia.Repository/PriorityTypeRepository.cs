using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class PriorityTypeRepository : BaseRepository<PriorityType>, IPriorityTypeRepository
    {
        private readonly DomainContext _context;

        public PriorityTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<PriorityType> PriorityType => _context.Set<PriorityType>();

        public async Task Add(PriorityType priorityType, CancellationToken cancellationToken = default)
        {
            _context.Add(priorityType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(PriorityType priorityType, CancellationToken cancellationToken = default)
        {
            _context.Set<PriorityType>().Remove(priorityType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<PriorityType> Get(int id)
        {
            return await PriorityType.SingleOrDefaultAsync(PriorityType => PriorityType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<PriorityType>> GetAll()
        {
            return (await PriorityType.ToListAsync().ConfigureAwait(false)).OrderBy(PriorityType => PriorityType.Name);
        }

        public async Task Update(PriorityType priorityType, CancellationToken cancellationToken = default)
        {
            _context.Set<PriorityType>().Update(priorityType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
