using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class PersonOccupationRepository : BaseRepository<PersonOccupation>, IPersonOccupationRepository
    {
        private readonly DomainContext _context;

        public PersonOccupationRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<PersonOccupation> PersonOccupation => _context.Set<PersonOccupation>()
                                                                         .Include(personOccupation => personOccupation.Person);

        public async Task Add(PersonOccupation personOccupation, CancellationToken cancellationToken = default)
        {
            _context.Add(personOccupation);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(PersonOccupation personOccupation, CancellationToken cancellationToken = default)
        {
            _context.Set<PersonOccupation>().Remove(personOccupation);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<PersonOccupation> Get(int id)
        {
            return await PersonOccupation.SingleOrDefaultAsync(personOccupation => personOccupation.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<PersonOccupation>> GetAll(int? personId = null)
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

        public async Task Update(PersonOccupation personOccupation, CancellationToken cancellationToken = default)
        {
            _context.Set<PersonOccupation>().Update(personOccupation);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
