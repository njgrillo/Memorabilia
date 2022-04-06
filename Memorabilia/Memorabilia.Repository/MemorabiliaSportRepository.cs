using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaSportRepository : BaseRepository<MemorabiliaSport>, IMemorabiliaSportRepository
    {
        private readonly Context _context;

        public MemorabiliaSportRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<MemorabiliaSport> MemorabiliaSport => _context.Set<MemorabiliaSport>();

        public async Task Add(MemorabiliaSport memorabiliaSport, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaSport);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(MemorabiliaSport memorabiliaSport, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaSport>().Remove(memorabiliaSport);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<MemorabiliaSport> Get(int id)
        {
            return await MemorabiliaSport.SingleOrDefaultAsync(memorabiliaSport => memorabiliaSport.Id == id).ConfigureAwait(false);
        }

        public async Task Update(MemorabiliaSport memorabiliaSport, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaSport>().Update(memorabiliaSport);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
