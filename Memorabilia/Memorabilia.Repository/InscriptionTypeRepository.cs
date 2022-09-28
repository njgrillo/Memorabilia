using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class InscriptionTypeRepository : BaseRepository<InscriptionType>, IInscriptionTypeRepository
    {
        private readonly DomainContext _context;

        public InscriptionTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<InscriptionType> InscriptionType => _context.Set<InscriptionType>();

        public async Task Add(InscriptionType inscriptionType, CancellationToken cancellationToken = default)
        {
            _context.Add(inscriptionType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(InscriptionType inscriptionType, CancellationToken cancellationToken = default)
        {
            _context.Set<InscriptionType>().Remove(inscriptionType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<InscriptionType> Get(int id)
        {
            return await InscriptionType.SingleOrDefaultAsync(inscriptionType => inscriptionType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<InscriptionType>> GetAll()
        {
            return (await InscriptionType.ToListAsync().ConfigureAwait(false)).OrderBy(inscriptionType => inscriptionType.Name);
        }

        public async Task Update(InscriptionType inscriptionType, CancellationToken cancellationToken = default)
        {
            _context.Set<InscriptionType>().Update(inscriptionType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
