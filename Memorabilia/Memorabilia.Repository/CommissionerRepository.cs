using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class CommissionerRepository : BaseRepository<Commissioner>, ICommissionerRepository
    {
        private readonly DomainContext _context;

        public CommissionerRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Commissioner> Commissioner => _context.Set<Commissioner>()
                                                                 .Include(commissioner => commissioner.Person);

        public async Task Add(Commissioner commissioner, CancellationToken cancellationToken = default)
        {
            _context.Add(commissioner);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Commissioner commissioner, CancellationToken cancellationToken = default)
        {
            _context.Set<Commissioner>().Remove(commissioner);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Commissioner> Get(int id)
        {
            return await Commissioner.SingleOrDefaultAsync(commissioner => commissioner.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Commissioner>> GetAll(int? sportLeagueLevelId = null)
        {
            return !sportLeagueLevelId.HasValue
                ? (await Commissioner.ToListAsync()
                                     .ConfigureAwait(false)).OrderBy(commissioner => commissioner.SportLeagueLevelName)
                                                            .ThenByDescending(commissioner => commissioner.BeginYear)
                : (await Commissioner.Where(commissioner => commissioner.SportLeagueLevelId == sportLeagueLevelId)
                                     .ToListAsync()
                                     .ConfigureAwait(false)).OrderBy(commissioner => commissioner.SportLeagueLevelName)
                                                            .ThenByDescending(commissioner => commissioner.BeginYear);
        }

        public async Task Update(Commissioner commissioner, CancellationToken cancellationToken = default)
        {
            _context.Set<Commissioner>().Update(commissioner);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
