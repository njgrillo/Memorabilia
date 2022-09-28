using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class PewterRepository : BaseRepository<Pewter>, IPewterRepository
    {
        private readonly DomainContext _context;

        public PewterRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Pewter> Pewter => _context.Set<Pewter>().Include(pewter => pewter.Team);

        public async Task Add(Pewter pewter, CancellationToken cancellationToken = default)
        {
            _context.Add(pewter);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Pewter pewter, CancellationToken cancellationToken = default)
        {
            _context.Set<Pewter>().Remove(pewter);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Pewter> Get(int id)
        {
            return await Pewter.SingleOrDefaultAsync(pewter => pewter.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Pewter>> GetAll()
        {
            return (await Pewter.ToListAsync()
                                .ConfigureAwait(false)).OrderBy(pewter => pewter.FranchiseName)
                                                       .ThenBy(pewter => pewter.Team.Name)
                                                       .ThenBy(pewter => pewter.SizeName)
                                                       .ThenBy(pewter => pewter.ImageTypeName);
        }

        public async Task Update(Pewter pewter, CancellationToken cancellationToken = default)
        {
            _context.Set<Pewter>().Update(pewter);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
