using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class HallOfFameRepository : BaseRepository<HallOfFame>, IHallOfFameRepository
    {
        private readonly DomainContext _context;

        public HallOfFameRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<HallOfFame> HallOfFame => _context.Set<HallOfFame>();

        public async Task Add(HallOfFame hallOfFame, CancellationToken cancellationToken = default)
        {
            _context.Add(hallOfFame);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(HallOfFame hallOfFame, CancellationToken cancellationToken = default)
        {
            _context.Set<HallOfFame>().Remove(hallOfFame);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<HallOfFame> Get(int id)
        {
            return await HallOfFame.SingleOrDefaultAsync(hallOfFame => hallOfFame.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<HallOfFame>> GetAll(int? personId = null)
        {
            return personId.HasValue 
                ? (await HallOfFame.Where(hof => hof.PersonId == personId)
                                   .ToListAsync()
                                   .ConfigureAwait(false)).OrderBy(hallOfFame => hallOfFame.Id)
                : (await HallOfFame.ToListAsync()
                                   .ConfigureAwait(false)).OrderBy(hallOfFame => hallOfFame.Id);
        }

        public async Task Update(HallOfFame hallOfFame, CancellationToken cancellationToken = default)
        {
            _context.Set<HallOfFame>().Update(hallOfFame);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
