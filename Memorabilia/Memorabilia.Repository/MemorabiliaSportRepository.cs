using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaSportRepository : BaseRepository<Domain.Entities.MemorabiliaSport>, IMemorabiliaSportRepository
    {
        private readonly Context _context;

        public MemorabiliaSportRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.MemorabiliaSport> MemorabiliaSport => _context.Set<Domain.Entities.MemorabiliaSport>();

        public async Task Add(Domain.Entities.MemorabiliaSport memorabiliaSport, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaSport);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.MemorabiliaSport memorabiliaSport, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaSport>().Remove(memorabiliaSport);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.MemorabiliaSport> Get(int id)
        {
            return await MemorabiliaSport.SingleOrDefaultAsync(memorabiliaSport => memorabiliaSport.Id == id).ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.MemorabiliaSport memorabiliaSport, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaSport>().Update(memorabiliaSport);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
