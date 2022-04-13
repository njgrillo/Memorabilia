using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class PersonNicknameRepository : BaseRepository<PersonNickname>, IPersonNicknameRepository
    {
        private readonly DomainContext _context;

        public PersonNicknameRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<PersonNickname> PersonNickname => _context.Set<PersonNickname>();

        public async Task Add(PersonNickname personNickname, CancellationToken cancellationToken = default)
        {
            _context.Add(personNickname);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(PersonNickname personNickname, CancellationToken cancellationToken = default)
        {
            _context.Set<PersonNickname>().Remove(personNickname);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<PersonNickname> Get(int id)
        {
            return await PersonNickname.SingleOrDefaultAsync(personNickname => personNickname.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<PersonNickname>> GetAll(int? personId = null)
        {
            return personId.HasValue
                ? (await PersonNickname.Where(personNickname => personNickname.PersonId == personId)
                                         .ToListAsync()
                                         .ConfigureAwait(false)).OrderBy(personNickname => personNickname.Nickname)
                : (await PersonNickname.ToListAsync()
                                         .ConfigureAwait(false)).OrderBy(personNickname => personNickname.Nickname);
        }

        public async Task Update(PersonNickname personNickname, CancellationToken cancellationToken = default)
        {
            _context.Set<PersonNickname>().Update(personNickname);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
