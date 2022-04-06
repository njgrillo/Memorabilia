using Memorabilia.Domain;
using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class FigureTypeRepository : BaseRepository<FigureType>, IFigureTypeRepository
    {
        private readonly DomainContext _context;

        public FigureTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<FigureType> FigureType => _context.Set<FigureType>();

        public async Task Add(FigureType figureType, CancellationToken cancellationToken = default)
        {
            _context.Add(figureType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(FigureType figureType, CancellationToken cancellationToken = default)
        {
            _context.Set<FigureType>().Remove(figureType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<FigureType> Get(int id)
        {
            return await FigureType.SingleOrDefaultAsync(figureType => figureType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<FigureType>> GetAll()
        {
            return (await FigureType.ToListAsync().ConfigureAwait(false)).OrderBy(FigureType => FigureType.Name);
        }

        public async Task Update(FigureType figureType, CancellationToken cancellationToken = default)
        {
            _context.Set<FigureType>().Update(figureType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
