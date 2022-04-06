using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class FigureSpecialtyTypeRepository : BaseRepository<FigureSpecialtyType>, IFigureSpecialtyTypeRepository
    {
        private readonly DomainContext _context;

        public FigureSpecialtyTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<FigureSpecialtyType> FigureSpecialtyType => _context.Set<FigureSpecialtyType>();

        public async Task Add(FigureSpecialtyType figureSpecialtyType, CancellationToken cancellationToken = default)
        {
            _context.Add(figureSpecialtyType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(FigureSpecialtyType figureSpecialtyType, CancellationToken cancellationToken = default)
        {
            _context.Set<FigureSpecialtyType>().Remove(figureSpecialtyType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<FigureSpecialtyType> Get(int id)
        {
            return await FigureSpecialtyType.SingleOrDefaultAsync(figureSpecialtyType => figureSpecialtyType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<FigureSpecialtyType>> GetAll()
        {
            return (await FigureSpecialtyType.ToListAsync().ConfigureAwait(false)).OrderBy(FigureSpecialtyType => FigureSpecialtyType.Name);
        }

        public async Task Update(FigureSpecialtyType figureSpecialtyType, CancellationToken cancellationToken = default)
        {
            _context.Set<FigureSpecialtyType>().Update(figureSpecialtyType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
