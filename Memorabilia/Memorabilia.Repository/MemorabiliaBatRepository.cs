using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaBatRepository : BaseRepository<Domain.Entities.MemorabiliaBat>, IMemorabiliaBatRepository
    {
        private readonly Context _context;

        public MemorabiliaBatRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.MemorabiliaBat> MemorabiliaBat => _context.Set<Domain.Entities.MemorabiliaBat>();

        public async Task Add(Domain.Entities.MemorabiliaBat memorabiliaBat, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaBat);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.MemorabiliaBat memorabiliaBat, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaBat>().Remove(memorabiliaBat);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.MemorabiliaBat> Get(int id)
        {
            return await MemorabiliaBat.SingleOrDefaultAsync(memorabiliaBat => memorabiliaBat.Id == id).ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.MemorabiliaBat memorabiliaBat, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaBat>().Update(memorabiliaBat);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
