using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class AcquisitionTypeRepository : BaseRepository<AcquisitionType>, IAcquisitionTypeRepository
    {
        private readonly DomainContext _context;

        public AcquisitionTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<AcquisitionType> AcquisitionType => _context.Set<AcquisitionType>();

        public async Task Add(AcquisitionType acquisitionType, CancellationToken cancellationToken = default)
        {
            _context.Add(acquisitionType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(AcquisitionType acquisitionType, CancellationToken cancellationToken = default)
        {
            _context.Set<AcquisitionType>().Remove(acquisitionType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<AcquisitionType> Get(int id)
        {
            return await AcquisitionType.SingleOrDefaultAsync(acquisitionType => acquisitionType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<AcquisitionType>> GetAll()
        {
            return (await AcquisitionType.ToListAsync().ConfigureAwait(false)).OrderBy(acquisitionType => acquisitionType.Name);
        }

        public async Task Update(AcquisitionType acquisitionType, CancellationToken cancellationToken = default)
        {
            _context.Set<AcquisitionType>().Update(acquisitionType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
