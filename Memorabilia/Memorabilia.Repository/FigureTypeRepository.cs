using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class FigureTypeRepository : BaseRepository<Domain.Entities.FigureType>, IFigureTypeRepository
    {
        private readonly Context _context;

        public FigureTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.FigureType> FigureType => _context.Set<Domain.Entities.FigureType>();

        public async Task Add(Domain.Entities.FigureType figureType, CancellationToken cancellationToken = default)
        {
            _context.Add(figureType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.FigureType figureType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.FigureType>().Remove(figureType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.FigureType> Get(int id)
        {
            return await FigureType.SingleOrDefaultAsync(figureType => figureType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.FigureType>> GetAll()
        {
            return (await FigureType.ToListAsync().ConfigureAwait(false)).OrderBy(FigureType => FigureType.Name);
        }

        public async Task Update(Domain.Entities.FigureType figureType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.FigureType>().Update(figureType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
