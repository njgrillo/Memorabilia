using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class ConditionRepository : BaseRepository<Domain.Entities.Condition>, IConditionRepository
    {
        private readonly Context _context;

        public ConditionRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.Condition> Condition => _context.Set<Domain.Entities.Condition>();

        public async Task Add(Domain.Entities.Condition condition, CancellationToken cancellationToken = default)
        {
            _context.Add(condition);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.Condition condition, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Condition>().Remove(condition);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.Condition> Get(int id)
        {
            return await Condition.SingleOrDefaultAsync(condition => condition.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.Condition>> GetAll()
        {
            return (await Condition.ToListAsync().ConfigureAwait(false)).OrderBy(condition => condition.Name);
        }

        public async Task Update(Domain.Entities.Condition condition, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Condition>().Update(condition);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
