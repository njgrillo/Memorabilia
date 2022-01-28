using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IAuthenticationCompanyRepository
    {
        Task Add(Entities.AuthenticationCompany authenticationCompany, CancellationToken cancellationToken = default);

        Task Delete(Entities.AuthenticationCompany authenticationCompany, CancellationToken cancellationToken = default);

        Task<Entities.AuthenticationCompany> Get(int id);

        Task<IEnumerable<Entities.AuthenticationCompany>> GetAll();

        Task Update(Entities.AuthenticationCompany authenticationCompany, CancellationToken cancellationToken = default);
    }
}
