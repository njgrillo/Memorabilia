using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class ImageTypeRepository : BaseRepository<ImageType>, IImageTypeRepository
    {
        private readonly DomainContext _context;

        public ImageTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<ImageType> ImageType => _context.Set<ImageType>();

        public async Task Add(ImageType imageType, CancellationToken cancellationToken = default)
        {
            _context.Add(imageType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(ImageType imageType, CancellationToken cancellationToken = default)
        {
            _context.Set<ImageType>().Remove(imageType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<ImageType> Get(int id)
        {
            return await ImageType.SingleOrDefaultAsync(imageType => imageType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ImageType>> GetAll()
        {
            return (await ImageType.ToListAsync().ConfigureAwait(false)).OrderBy(imageType => imageType.Name);
        }

        public async Task Update(ImageType imageType, CancellationToken cancellationToken = default)
        {
            _context.Set<ImageType>().Update(imageType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
