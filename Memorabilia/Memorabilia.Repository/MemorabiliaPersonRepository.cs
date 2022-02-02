using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaPersonRepository : BaseRepository<Domain.Entities.MemorabiliaPerson>, IMemorabiliaPersonRepository
    {
        private readonly Context _context;

        public MemorabiliaPersonRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.MemorabiliaPerson> MemorabiliaPerson => _context.Set<Domain.Entities.MemorabiliaPerson>();

        public async Task Add(Domain.Entities.MemorabiliaPerson memorabiliaPerson, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaPerson);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(IEnumerable<Domain.Entities.MemorabiliaPerson> memorabiliaPeople, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaPerson>().RemoveRange(memorabiliaPeople);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.MemorabiliaPerson> Get(int id)
        {
            return await MemorabiliaPerson.SingleOrDefaultAsync(memorabiliaPerson => memorabiliaPerson.Id == id).ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.MemorabiliaPerson memorabiliaPerson, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaPerson>().Update(memorabiliaPerson);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
