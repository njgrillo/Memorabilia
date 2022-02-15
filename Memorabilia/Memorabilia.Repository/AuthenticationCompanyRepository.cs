using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class AuthenticationCompanyRepository : BaseRepository<Domain.Entities.AuthenticationCompany>, IAuthenticationCompanyRepository
    {
        private readonly Context _context;

        public AuthenticationCompanyRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.AuthenticationCompany> AuthenticationCompany => _context.Set<Domain.Entities.AuthenticationCompany>();

        public async Task Add(Domain.Entities.AuthenticationCompany authenticationCompany, CancellationToken cancellationToken = default)
        {
            _context.Add(authenticationCompany);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.AuthenticationCompany authenticationCompany, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.AuthenticationCompany>().Remove(authenticationCompany);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.AuthenticationCompany> Get(int id)
        {
            return await AuthenticationCompany.SingleOrDefaultAsync(authenticationCompany => authenticationCompany.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.AuthenticationCompany>> GetAll()
        {
            return (await AuthenticationCompany.ToListAsync().ConfigureAwait(false)).OrderBy(authenticationCompany => authenticationCompany.Name);
        }

        public async Task Update(Domain.Entities.AuthenticationCompany authenticationCompany, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.AuthenticationCompany>().Update(authenticationCompany);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
