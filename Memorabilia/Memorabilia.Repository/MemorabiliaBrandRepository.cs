using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaBrandRepository : BaseRepository<MemorabiliaBrand>, IMemorabiliaBrandRepository
    {
        private readonly Context _context;

        public MemorabiliaBrandRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<MemorabiliaBrand> MemorabiliaBrand => _context.Set<MemorabiliaBrand>();

        public async Task Add(MemorabiliaBrand memorabiliaBrand, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaBrand);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(MemorabiliaBrand memorabiliaBrand, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaBrand>().Remove(memorabiliaBrand);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<MemorabiliaBrand> Get(int id)
        {
            return await MemorabiliaBrand.SingleOrDefaultAsync(memorabiliaBrand => memorabiliaBrand.Id == id).ConfigureAwait(false);
        }

        public async Task Update(MemorabiliaBrand memorabiliaBrand, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaBrand>().Update(memorabiliaBrand);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
