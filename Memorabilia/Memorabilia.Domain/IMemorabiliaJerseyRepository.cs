using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IMemorabiliaJerseyRepository
    {
        Task Add(Entities.MemorabiliaJersey memorabiliaJersey, CancellationToken cancellationToken = default);

        Task Delete(Entities.MemorabiliaJersey memorabiliaJersey, CancellationToken cancellationToken = default);

        Task<Entities.MemorabiliaJersey> Get(int id);

        Task Update(Entities.MemorabiliaJersey memorabiliaJersey, CancellationToken cancellationToken = default);
    }
}
