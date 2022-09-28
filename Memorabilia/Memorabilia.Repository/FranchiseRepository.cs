using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class FranchiseRepository : BaseRepository<Franchise>, IFranchiseRepository
    {
        private readonly DomainContext _context;

        public FranchiseRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Franchise> Franchise => _context.Set<Franchise>();

        public async Task Add(Franchise franchise, CancellationToken cancellationToken = default)
        {
            _context.Add(franchise);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Franchise franchise, CancellationToken cancellationToken = default)
        {
            _context.Set<Franchise>().Remove(franchise);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Franchise> Get(int id)
        {
            return await Franchise.SingleOrDefaultAsync(franchise => franchise.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Franchise>> GetAll()
        {
            return (await Franchise.ToListAsync()
                                   .ConfigureAwait(false)).OrderBy(franchise => franchise.SportLeagueLevelName)
                                                          .ThenBy(franchise => franchise.Name);
        }

        public async Task Update(Franchise franchise, CancellationToken cancellationToken = default)
        {
            _context.Set<Franchise>().Update(franchise);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
