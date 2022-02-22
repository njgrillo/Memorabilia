using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class ConferenceRepository : BaseRepository<Domain.Entities.Conference>, IConferenceRepository
    {
        private readonly Context _context;

        public ConferenceRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.Conference> Conference => _context.Set<Domain.Entities.Conference>();

        public async Task Add(Domain.Entities.Conference conference, CancellationToken cancellationToken = default)
        {
            _context.Add(conference);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.Conference conference, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Conference>().Remove(conference);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.Conference> Get(int id)
        {
            return await Conference.SingleOrDefaultAsync(conference => conference.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.Conference>> GetAll()
        {
            return (await Conference.ToListAsync()
                                    .ConfigureAwait(false)).OrderBy(conference => conference.SportLeagueLevelName)
                                                           .ThenBy(conference => conference.Name);
        }

        public async Task Update(Domain.Entities.Conference conference, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Conference>().Update(conference);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
