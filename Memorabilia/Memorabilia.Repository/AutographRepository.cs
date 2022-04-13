using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class AutographRepository : BaseRepository<Autograph>, IAutographRepository
    {
        private readonly MemorabiliaContext _context;

        public AutographRepository(MemorabiliaContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Autograph> Autograph => _context.Set<Autograph>()
                                                           .Include(autograph => autograph.Acquisition)
                                                           .Include(autograph => autograph.Authentications)
                                                           .Include(autograph => autograph.Images)
                                                           .Include(autograph => autograph.Inscriptions)
                                                           .Include(autograph => autograph.Memorabilia)
                                                           .Include(autograph => autograph.Person)
                                                           .Include(autograph => autograph.Personalization)
                                                           .Include(autograph => autograph.Spot);

        public async Task Add(Autograph autograph, CancellationToken cancellationToken = default)
        {
            _context.Add(autograph);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Autograph autograph, CancellationToken cancellationToken = default)
        {
            _context.Set<Autograph>().Remove(autograph);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Autograph> Get(int id)
        {
            return await Autograph.SingleOrDefaultAsync(autograph => autograph.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Autograph>> GetAll(int? memorabiliaId = null, int? userId = null)
        {
            if (memorabiliaId.HasValue)
                return await Autograph.Where(autograph => autograph.MemorabiliaId == memorabiliaId).ToListAsync().ConfigureAwait(false);

            if (userId.HasValue)
                return await Autograph.Where(autograph => autograph.Memorabilia.UserId == userId).ToListAsync().ConfigureAwait(false);

            return await Autograph.ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(Autograph autograph, CancellationToken cancellationToken = default)
        {
            _context.Set<Autograph>().Update(autograph);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
