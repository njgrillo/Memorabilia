using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class ConditionRepository : BaseRepository<Condition>, IConditionRepository
    {
        private readonly DomainContext _context;

        public ConditionRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Condition> Condition => _context.Set<Condition>();

        public async Task Add(Condition condition, CancellationToken cancellationToken = default)
        {
            _context.Add(condition);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Condition condition, CancellationToken cancellationToken = default)
        {
            _context.Set<Condition>().Remove(condition);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Condition> Get(int id)
        {
            return await Condition.SingleOrDefaultAsync(condition => condition.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Condition>> GetAll()
        {
            return (await Condition.ToListAsync().ConfigureAwait(false)).OrderBy(condition => condition.Name);
        }

        public async Task Update(Condition condition, CancellationToken cancellationToken = default)
        {
            _context.Set<Condition>().Update(condition);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
