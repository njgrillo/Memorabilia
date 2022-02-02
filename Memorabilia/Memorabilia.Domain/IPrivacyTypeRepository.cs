using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IPrivacyTypeRepository
    {
        Task Add(Entities.PrivacyType privacyType, CancellationToken cancellationToken = default);

        Task Delete(Entities.PrivacyType privacyType, CancellationToken cancellationToken = default);

        Task<Entities.PrivacyType> Get(int id);

        Task<IEnumerable<Entities.PrivacyType>> GetAll();

        Task Update(Entities.PrivacyType privacyType, CancellationToken cancellationToken = default);
    }
}
