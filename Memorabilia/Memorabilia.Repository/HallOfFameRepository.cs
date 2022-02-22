using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class HallOfFameRepository : BaseRepository<Domain.Entities.HallOfFame>, IHallOfFameRepository
    {
        private readonly Context _context;

        public HallOfFameRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.HallOfFame> HallOfFame => _context.Set<Domain.Entities.HallOfFame>();

        public async Task Add(Domain.Entities.HallOfFame hallOfFame, CancellationToken cancellationToken = default)
        {
            _context.Add(hallOfFame);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.HallOfFame hallOfFame, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.HallOfFame>().Remove(hallOfFame);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.HallOfFame> Get(int id)
        {
            return await HallOfFame.SingleOrDefaultAsync(hallOfFame => hallOfFame.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.HallOfFame>> GetAll(int? personId = null)
        {
            return personId.HasValue 
                ? (await HallOfFame.Where(hof => hof.PersonId == personId)
                                   .ToListAsync()
                                   .ConfigureAwait(false)).OrderBy(hallOfFame => hallOfFame.Id)
                : (await HallOfFame.ToListAsync()
                                   .ConfigureAwait(false)).OrderBy(hallOfFame => hallOfFame.Id);
        }

        public async Task Update(Domain.Entities.HallOfFame hallOfFame, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.HallOfFame>().Update(hallOfFame);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
