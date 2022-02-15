using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaRepository : BaseRepository<Domain.Entities.Memorabilia>, IMemorabiliaRepository
    {
        private readonly Context _context;

        public MemorabiliaRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.Memorabilia> Memorabilia => _context.Set<Domain.Entities.Memorabilia>()
                                                                               .Include(memorabilia => memorabilia.Autographs)
                                                                               .Include(memorabilia => memorabilia.Baseball)
                                                                               .Include(memorabilia => memorabilia.Basketball)
                                                                               .Include(memorabilia => memorabilia.Bat)
                                                                               .Include(memorabilia => memorabilia.Brand)
                                                                               .Include(memorabilia => memorabilia.Card)
                                                                               .Include(memorabilia => memorabilia.Commissioner)
                                                                               .Include(memorabilia => memorabilia.Football)
                                                                               .Include(memorabilia => memorabilia.Game)
                                                                               .Include(memorabilia => memorabilia.Images)
                                                                               .Include(memorabilia => memorabilia.Jersey)
                                                                               .Include(memorabilia => memorabilia.LevelType)
                                                                               .Include(memorabilia => memorabilia.Magazine)
                                                                               .Include(memorabilia => memorabilia.MemorabiliaAcquisition)
                                                                               .Include(memorabilia => memorabilia.MemorabiliaAcquisition.Acquisition)
                                                                               .Include(memorabilia => memorabilia.Orientation)
                                                                               .Include(memorabilia => memorabilia.People)
                                                                               .Include(memorabilia => memorabilia.Photo)
                                                                               .Include(memorabilia => memorabilia.Size)
                                                                               .Include(memorabilia => memorabilia.Sports)
                                                                               .Include(memorabilia => memorabilia.Teams)
                                                                               .Include(memorabilia => memorabilia.User);

        public async Task Add(Domain.Entities.Memorabilia memorabilia, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabilia);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.Memorabilia memorabilia, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Memorabilia>().Remove(memorabilia);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.Memorabilia> Get(int id)
        {
            return await Memorabilia.SingleOrDefaultAsync(memorabilia => memorabilia.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.Memorabilia>> GetAll(int userId)
        {
            return await Memorabilia.Where(memorabilia => memorabilia.UserId == userId).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.Memorabilia>> GetAllUnsigned(int userId)
        {
            return await Memorabilia.Where(memorabilia => memorabilia.UserId == userId && !memorabilia.Autographs.Any()).ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.Memorabilia memorabilia, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Memorabilia>().Update(memorabilia);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
