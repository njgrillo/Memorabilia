using Memorabilia.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IMemorabiliaJerseyRepository
    {
        Task Add(MemorabiliaJersey memorabiliaJersey, CancellationToken cancellationToken = default);

        Task Delete(MemorabiliaJersey memorabiliaJersey, CancellationToken cancellationToken = default);

        Task<MemorabiliaJersey> Get(int id);

        Task Update(MemorabiliaJersey memorabiliaJersey, CancellationToken cancellationToken = default);
    }
}
