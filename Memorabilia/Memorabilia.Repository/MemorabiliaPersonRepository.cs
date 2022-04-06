using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaPersonRepository : BaseRepository<MemorabiliaPerson>, IMemorabiliaPersonRepository
    {
        private readonly Context _context;

        public MemorabiliaPersonRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<MemorabiliaPerson> MemorabiliaPerson => _context.Set<MemorabiliaPerson>();

        public async Task Add(MemorabiliaPerson memorabiliaPerson, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaPerson);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(IEnumerable<MemorabiliaPerson> memorabiliaPeople, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaPerson>().RemoveRange(memorabiliaPeople);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<MemorabiliaPerson> Get(int id)
        {
            return await MemorabiliaPerson.SingleOrDefaultAsync(memorabiliaPerson => memorabiliaPerson.Id == id).ConfigureAwait(false);
        }

        public async Task Update(MemorabiliaPerson memorabiliaPerson, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaPerson>().Update(memorabiliaPerson);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
