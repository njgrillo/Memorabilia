using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaBrandRepository : BaseRepository<Domain.Entities.MemorabiliaBrand>, IMemorabiliaBrandRepository
    {
        private readonly Context _context;

        public MemorabiliaBrandRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.MemorabiliaBrand> MemorabiliaBrand => _context.Set<Domain.Entities.MemorabiliaBrand>();

        public async Task Add(Domain.Entities.MemorabiliaBrand memorabiliaBrand, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaBrand);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.MemorabiliaBrand memorabiliaBrand, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaBrand>().Remove(memorabiliaBrand);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.MemorabiliaBrand> Get(int id)
        {
            return await MemorabiliaBrand.SingleOrDefaultAsync(memorabiliaBrand => memorabiliaBrand.Id == id).ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.MemorabiliaBrand memorabiliaBrand, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaBrand>().Update(memorabiliaBrand);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
