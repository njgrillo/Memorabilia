using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class ColorRepository : BaseRepository<Color>, IColorRepository
    {
        private readonly DomainContext _context;

        public ColorRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Color> Color => _context.Set<Color>();

        public async Task Add(Color color, CancellationToken cancellationToken = default)
        {
            _context.Add(color);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Color color, CancellationToken cancellationToken = default)
        {
            _context.Set<Color>().Remove(color);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Color> Get(int id)
        {
            return await Color.SingleOrDefaultAsync(color => color.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Color>> GetAll()
        {
            return (await Color.ToListAsync().ConfigureAwait(false)).OrderBy(color => color.Name);
        }

        public async Task Update(Color color, CancellationToken cancellationToken = default)
        {
            _context.Set<Color>().Update(color);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
