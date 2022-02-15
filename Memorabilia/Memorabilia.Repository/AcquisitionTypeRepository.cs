using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class AcquisitionTypeRepository : BaseRepository<Domain.Entities.AcquisitionType>, IAcquisitionTypeRepository
    {
        private readonly Context _context;

        public AcquisitionTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.AcquisitionType> AcquisitionType => _context.Set<Domain.Entities.AcquisitionType>();

        public async Task Add(Domain.Entities.AcquisitionType acquisitionType, CancellationToken cancellationToken = default)
        {
            _context.Add(acquisitionType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.AcquisitionType acquisitionType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.AcquisitionType>().Remove(acquisitionType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.AcquisitionType> Get(int id)
        {
            return await AcquisitionType.SingleOrDefaultAsync(acquisitionType => acquisitionType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.AcquisitionType>> GetAll()
        {
            return (await AcquisitionType.ToListAsync().ConfigureAwait(false)).OrderBy(acquisitionType => acquisitionType.Name);
        }

        public async Task Update(Domain.Entities.AcquisitionType acquisitionType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.AcquisitionType>().Update(acquisitionType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
