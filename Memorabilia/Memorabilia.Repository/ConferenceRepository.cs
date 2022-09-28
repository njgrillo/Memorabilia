using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class ConferenceRepository : BaseRepository<Conference>, IConferenceRepository
    {
        private readonly DomainContext _context;

        public ConferenceRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Conference> Conference => _context.Set<Conference>();

        public async Task Add(Conference conference, CancellationToken cancellationToken = default)
        {
            _context.Add(conference);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Conference conference, CancellationToken cancellationToken = default)
        {
            _context.Set<Conference>().Remove(conference);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Conference> Get(int id)
        {
            return await Conference.SingleOrDefaultAsync(conference => conference.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Conference>> GetAll()
        {
            return (await Conference.ToListAsync()
                                    .ConfigureAwait(false)).OrderBy(conference => conference.SportLeagueLevelName)
                                                           .ThenBy(conference => conference.Name);
        }

        public async Task Update(Conference conference, CancellationToken cancellationToken = default)
        {
            _context.Set<Conference>().Update(conference);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
