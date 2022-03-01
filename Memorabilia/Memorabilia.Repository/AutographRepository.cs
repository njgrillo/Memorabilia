using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class AutographRepository : BaseRepository<Domain.Entities.Autograph>, IAutographRepository
    {
        private readonly Context _context;

        public AutographRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.Autograph> Autograph => _context.Set<Domain.Entities.Autograph>()
                                                                           .Include(autograph => autograph.Acquisition)
                                                                           .Include(autograph => autograph.Authentications)
                                                                           .Include(autograph => autograph.Images)
                                                                           .Include(autograph => autograph.Inscriptions)
                                                                           .Include(autograph => autograph.Memorabilia)
                                                                           .Include(autograph => autograph.Person)
                                                                           .Include(autograph => autograph.Personalization)
                                                                           .Include(autograph => autograph.Spot);

        public async Task Add(Domain.Entities.Autograph autograph, CancellationToken cancellationToken = default)
        {
            _context.Add(autograph);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.Autograph autograph, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Autograph>().Remove(autograph);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.Autograph> Get(int id)
        {
            return await Autograph.SingleOrDefaultAsync(autograph => autograph.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.Autograph>> GetAll(int? memorabiliaId = null, int? userId = null)
        {
            if (memorabiliaId.HasValue)
                return await Autograph.Where(autograph => autograph.MemorabiliaId == memorabiliaId).ToListAsync().ConfigureAwait(false);

            if (userId.HasValue)
                return await Autograph.Where(autograph => autograph.Memorabilia.UserId == userId).ToListAsync().ConfigureAwait(false);

            return await Autograph.ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.Autograph autograph, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Autograph>().Update(autograph);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
