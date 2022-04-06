using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaBatRepository : BaseRepository<MemorabiliaBat>, IMemorabiliaBatRepository
    {
        private readonly Context _context;

        public MemorabiliaBatRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<MemorabiliaBat> MemorabiliaBat => _context.Set<MemorabiliaBat>();

        public async Task Add(MemorabiliaBat memorabiliaBat, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaBat);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(MemorabiliaBat memorabiliaBat, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaBat>().Remove(memorabiliaBat);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<MemorabiliaBat> Get(int id)
        {
            return await MemorabiliaBat.SingleOrDefaultAsync(memorabiliaBat => memorabiliaBat.Id == id).ConfigureAwait(false);
        }

        public async Task Update(MemorabiliaBat memorabiliaBat, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaBat>().Update(memorabiliaBat);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
