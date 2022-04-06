using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaMagazineRepository : BaseRepository<MemorabiliaMagazine>, IMemorabiliaMagazineRepository
    {
        private readonly Context _context;

        public MemorabiliaMagazineRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<MemorabiliaMagazine> MemorabiliaMagazine => _context.Set<MemorabiliaMagazine>();

        public async Task Add(MemorabiliaMagazine memorabiliaMagazine, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaMagazine);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(MemorabiliaMagazine memorabiliaMagazine, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaMagazine>().Remove(memorabiliaMagazine);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<MemorabiliaMagazine> Get(int id)
        {
            return await MemorabiliaMagazine.SingleOrDefaultAsync(memorabiliaMagazine => memorabiliaMagazine.Id == id).ConfigureAwait(false);
        }

        public async Task Update(MemorabiliaMagazine memorabiliaMagazine, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaMagazine>().Update(memorabiliaMagazine);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
