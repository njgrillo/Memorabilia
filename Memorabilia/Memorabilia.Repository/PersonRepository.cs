using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class PersonRepository : BaseRepository<Domain.Entities.Person>, IPersonRepository
    {
        private readonly Context _context;

        public PersonRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.Person> Person => _context.Set<Domain.Entities.Person>();

        public async Task Add(Domain.Entities.Person person, CancellationToken cancellationToken = default)
        {
            _context.Add(person);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.Person person, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Person>().Remove(person);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.Person> Get(int id)
        {
            return await Person.SingleOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.Person>> GetAll()
        {
            return await Person.ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.Person person, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Person>().Update(person);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}