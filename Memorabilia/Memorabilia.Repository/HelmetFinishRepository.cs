using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class HelmetFinishRepository : BaseRepository<Domain.Entities.HelmetFinish>, IHelmetFinishRepository
    {
        private readonly Context _context;

        public HelmetFinishRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.HelmetFinish> HelmetFinish => _context.Set<Domain.Entities.HelmetFinish>();

        public async Task Add(Domain.Entities.HelmetFinish helmetFinish, CancellationToken cancellationToken = default)
        {
            _context.Add(helmetFinish);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.HelmetFinish helmetFinish, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.HelmetFinish>().Remove(helmetFinish);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.HelmetFinish> Get(int id)
        {
            return await HelmetFinish.SingleOrDefaultAsync(helmetFinish => helmetFinish.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.HelmetFinish>> GetAll()
        {
            return (await HelmetFinish.ToListAsync().ConfigureAwait(false)).OrderBy(helmetFinish => helmetFinish.Name);
        }

        public async Task Update(Domain.Entities.HelmetFinish helmetFinish, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.HelmetFinish>().Update(helmetFinish);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
