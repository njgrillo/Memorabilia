using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaFigureRepository : BaseRepository<Domain.Entities.MemorabiliaFigure>, IMemorabiliaFigureRepository
    {
        private readonly Context _context;

        public MemorabiliaFigureRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.MemorabiliaFigure> MemorabiliaFigure => _context.Set<Domain.Entities.MemorabiliaFigure>();

        public async Task Add(Domain.Entities.MemorabiliaFigure memorabiliaFigure, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaFigure);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.MemorabiliaFigure memorabiliaFigure, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaFigure>().Remove(memorabiliaFigure);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.MemorabiliaFigure> Get(int id)
        {
            return await MemorabiliaFigure.SingleOrDefaultAsync(memorabiliaFigure => memorabiliaFigure.Id == id).ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.MemorabiliaFigure memorabiliaFigure, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaFigure>().Update(memorabiliaFigure);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
