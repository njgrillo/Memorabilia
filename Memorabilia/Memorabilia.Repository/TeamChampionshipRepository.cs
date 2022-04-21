using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class TeamChampionshipRepository : BaseRepository<Champion>, ITeamChampionshipRepository
    {
        private readonly DomainContext _context;

        public TeamChampionshipRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Champion> Champion => _context.Set<Champion>();

        public async Task Add(Champion champion, CancellationToken cancellationToken = default)
        {
            _context.Add(champion);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Champion champion, CancellationToken cancellationToken = default)
        {
            _context.Set<Champion>().Remove(champion);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Champion> Get(int id)
        {
            return await Champion.SingleOrDefaultAsync(champion => champion.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Champion>> GetAll(int? teamId = null)
        {
            return teamId.HasValue
                ? (await Champion.Where(champion => champion.TeamId == teamId)
                                   .ToListAsync()
                                   .ConfigureAwait(false)).OrderBy(champion => champion.Year)
                : (await Champion.ToListAsync()
                                   .ConfigureAwait(false)).OrderBy(champion => champion.Year);
        }

        public async Task Update(Champion champion, CancellationToken cancellationToken = default)
        {
            _context.Set<Champion>().Update(champion);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
