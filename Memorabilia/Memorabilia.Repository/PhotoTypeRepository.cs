using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class PhotoTypeRepository : BaseRepository<PhotoType>, IPhotoTypeRepository
    {
        private readonly DomainContext _context;

        public PhotoTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<PhotoType> PhotoType => _context.Set<PhotoType>();

        public async Task Add(PhotoType photoType, CancellationToken cancellationToken = default)
        {
            _context.Add(photoType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(PhotoType photoType, CancellationToken cancellationToken = default)
        {
            _context.Set<PhotoType>().Remove(photoType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<PhotoType> Get(int id)
        {
            return await PhotoType.SingleOrDefaultAsync(photoType => photoType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<PhotoType>> GetAll()
        {
            return (await PhotoType.ToListAsync().ConfigureAwait(false)).OrderBy(photoType => photoType.Name);
        }

        public async Task Update(PhotoType photoType, CancellationToken cancellationToken = default)
        {
            _context.Set<PhotoType>().Update(photoType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
