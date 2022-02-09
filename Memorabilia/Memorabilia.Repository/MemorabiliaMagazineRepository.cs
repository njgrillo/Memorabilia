using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaMagazineRepository : BaseRepository<Domain.Entities.MemorabiliaMagazine>, IMemorabiliaMagazineRepository
    {
        private readonly Context _context;

        public MemorabiliaMagazineRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.MemorabiliaMagazine> MemorabiliaMagazine => _context.Set<Domain.Entities.MemorabiliaMagazine>();

        public async Task Add(Domain.Entities.MemorabiliaMagazine memorabiliaMagazine, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaMagazine);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.MemorabiliaMagazine memorabiliaMagazine, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaMagazine>().Remove(memorabiliaMagazine);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.MemorabiliaMagazine> Get(int id)
        {
            return await MemorabiliaMagazine.SingleOrDefaultAsync(memorabiliaMagazine => memorabiliaMagazine.Id == id).ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.MemorabiliaMagazine memorabiliaMagazine, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaMagazine>().Update(memorabiliaMagazine);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
