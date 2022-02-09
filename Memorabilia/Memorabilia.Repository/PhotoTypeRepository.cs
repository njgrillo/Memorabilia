using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class PhotoTypeRepository : BaseRepository<Domain.Entities.PhotoType>, IPhotoTypeRepository
    {
        private readonly Context _context;

        public PhotoTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.PhotoType> PhotoType => _context.Set<Domain.Entities.PhotoType>();

        public async Task Add(Domain.Entities.PhotoType photoType, CancellationToken cancellationToken = default)
        {
            _context.Add(photoType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.PhotoType photoType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.PhotoType>().Remove(photoType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.PhotoType> Get(int id)
        {
            return await PhotoType.SingleOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.PhotoType>> GetAll()
        {
            return await PhotoType.ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.PhotoType photoType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.PhotoType>().Update(photoType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
