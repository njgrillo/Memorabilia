using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class AuthenticationCompanyRepository : BaseRepository<AuthenticationCompany>, IAuthenticationCompanyRepository
    {
        private readonly DomainContext _context;

        public AuthenticationCompanyRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<AuthenticationCompany> AuthenticationCompany => _context.Set<AuthenticationCompany>();

        public async Task Add(AuthenticationCompany authenticationCompany, CancellationToken cancellationToken = default)
        {
            _context.Add(authenticationCompany);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(AuthenticationCompany authenticationCompany, CancellationToken cancellationToken = default)
        {
            _context.Set<AuthenticationCompany>().Remove(authenticationCompany);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<AuthenticationCompany> Get(int id)
        {
            return await AuthenticationCompany.SingleOrDefaultAsync(authenticationCompany => authenticationCompany.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<AuthenticationCompany>> GetAll()
        {
            return (await AuthenticationCompany.ToListAsync().ConfigureAwait(false)).OrderBy(authenticationCompany => authenticationCompany.Name);
        }

        public async Task Update(AuthenticationCompany authenticationCompany, CancellationToken cancellationToken = default)
        {
            _context.Set<AuthenticationCompany>().Update(authenticationCompany);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
