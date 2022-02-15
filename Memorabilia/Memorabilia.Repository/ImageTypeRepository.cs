using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class ImageTypeRepository : BaseRepository<Domain.Entities.ImageType>, IImageTypeRepository
    {
        private readonly Context _context;

        public ImageTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.ImageType> ImageType => _context.Set<Domain.Entities.ImageType>();

        public async Task Add(Domain.Entities.ImageType imageType, CancellationToken cancellationToken = default)
        {
            _context.Add(imageType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.ImageType imageType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.ImageType>().Remove(imageType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.ImageType> Get(int id)
        {
            return await ImageType.SingleOrDefaultAsync(imageType => imageType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.ImageType>> GetAll()
        {
            return (await ImageType.ToListAsync().ConfigureAwait(false)).OrderBy(imageType => imageType.Name);
        }

        public async Task Update(Domain.Entities.ImageType imageType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.ImageType>().Update(imageType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
