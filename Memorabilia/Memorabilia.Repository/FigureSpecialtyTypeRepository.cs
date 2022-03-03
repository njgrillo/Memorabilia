using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class FigureSpecialtyTypeRepository : BaseRepository<Domain.Entities.FigureSpecialtyType>, IFigureSpecialtyTypeRepository
    {
        private readonly Context _context;

        public FigureSpecialtyTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.FigureSpecialtyType> FigureSpecialtyType => _context.Set<Domain.Entities.FigureSpecialtyType>();

        public async Task Add(Domain.Entities.FigureSpecialtyType figureSpecialtyType, CancellationToken cancellationToken = default)
        {
            _context.Add(figureSpecialtyType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.FigureSpecialtyType figureSpecialtyType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.FigureSpecialtyType>().Remove(figureSpecialtyType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.FigureSpecialtyType> Get(int id)
        {
            return await FigureSpecialtyType.SingleOrDefaultAsync(figureSpecialtyType => figureSpecialtyType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.FigureSpecialtyType>> GetAll()
        {
            return (await FigureSpecialtyType.ToListAsync().ConfigureAwait(false)).OrderBy(FigureSpecialtyType => FigureSpecialtyType.Name);
        }

        public async Task Update(Domain.Entities.FigureSpecialtyType figureSpecialtyType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.FigureSpecialtyType>().Update(figureSpecialtyType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
