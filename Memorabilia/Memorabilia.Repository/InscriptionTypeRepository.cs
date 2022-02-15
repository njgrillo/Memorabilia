using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class InscriptionTypeRepository : BaseRepository<Domain.Entities.InscriptionType>, IInscriptionTypeRepository
    {
        private readonly Context _context;

        public InscriptionTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.InscriptionType> InscriptionType => _context.Set<Domain.Entities.InscriptionType>();

        public async Task Add(Domain.Entities.InscriptionType inscriptionType, CancellationToken cancellationToken = default)
        {
            _context.Add(inscriptionType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.InscriptionType inscriptionType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.InscriptionType>().Remove(inscriptionType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.InscriptionType> Get(int id)
        {
            return await InscriptionType.SingleOrDefaultAsync(inscriptionType => inscriptionType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.InscriptionType>> GetAll()
        {
            return (await InscriptionType.ToListAsync().ConfigureAwait(false)).OrderBy(inscriptionType => inscriptionType.Name);
        }

        public async Task Update(Domain.Entities.InscriptionType inscriptionType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.InscriptionType>().Update(inscriptionType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
