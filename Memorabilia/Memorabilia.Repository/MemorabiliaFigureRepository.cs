using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaFigureRepository : BaseRepository<MemorabiliaFigure>, IMemorabiliaFigureRepository
    {
        private readonly Context _context;

        public MemorabiliaFigureRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<MemorabiliaFigure> MemorabiliaFigure => _context.Set<MemorabiliaFigure>();

        public async Task Add(MemorabiliaFigure memorabiliaFigure, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaFigure);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(MemorabiliaFigure memorabiliaFigure, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaFigure>().Remove(memorabiliaFigure);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<MemorabiliaFigure> Get(int id)
        {
            return await MemorabiliaFigure.SingleOrDefaultAsync(memorabiliaFigure => memorabiliaFigure.Id == id).ConfigureAwait(false);
        }

        public async Task Update(MemorabiliaFigure memorabiliaFigure, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaFigure>().Update(memorabiliaFigure);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
