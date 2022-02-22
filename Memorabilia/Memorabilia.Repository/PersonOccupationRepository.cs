using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class PersonOccupationRepository : BaseRepository<Domain.Entities.PersonOccupation>, IPersonOccupationRepository
    {
        private readonly Context _context;

        public PersonOccupationRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.PersonOccupation> PersonOccupation => _context.Set<Domain.Entities.PersonOccupation>()
                                                                                         .Include(personOccupation => personOccupation.Person);

        public async Task Add(Domain.Entities.PersonOccupation personOccupation, CancellationToken cancellationToken = default)
        {
            _context.Add(personOccupation);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.PersonOccupation personOccupation, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.PersonOccupation>().Remove(personOccupation);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.PersonOccupation> Get(int id)
        {
            return await PersonOccupation.SingleOrDefaultAsync(personOccupation => personOccupation.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.PersonOccupation>> GetAll(int? personId = null)
        {
            return personId.HasValue
                ? (await PersonOccupation.Where(personOccupation => personOccupation.PersonId == personId)
                                         .ToListAsync()
                                         .ConfigureAwait(false)).OrderBy(personOccupation => personOccupation.OccupationName)
                                                                .ThenBy(personOccupation => personOccupation.Person?.DisplayName)
                : (await PersonOccupation.ToListAsync()
                                         .ConfigureAwait(false)).OrderBy(personOccupation => personOccupation.OccupationName)
                                                                .ThenBy(personOccupation => personOccupation.Person?.DisplayName);
        }

        public async Task Update(Domain.Entities.PersonOccupation personOccupation, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.PersonOccupation>().Update(personOccupation);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
