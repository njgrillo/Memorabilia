using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IAuthenticationCompanyRepository
    {
        Task Add(AuthenticationCompany authenticationCompany, CancellationToken cancellationToken = default);

        Task Delete(AuthenticationCompany authenticationCompany, CancellationToken cancellationToken = default);

        Task<AuthenticationCompany> Get(int id);

        Task<IEnumerable<AuthenticationCompany>> GetAll();

        Task Update(AuthenticationCompany authenticationCompany, CancellationToken cancellationToken = default);
    }
}
