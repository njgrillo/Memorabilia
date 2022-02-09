using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IAutographRepository
    {
        Task Add(Entities.Autograph autograph, CancellationToken cancellationToken = default);

        Task Delete(Entities.Autograph autograph, CancellationToken cancellationToken = default);

        Task<Entities.Autograph> Get(int id);

        Task<IEnumerable<Entities.Autograph>> GetAll(int? memorabiliaId = null);

        Task Update(Entities.Autograph autograph, CancellationToken cancellationToken = default);
    }
}
