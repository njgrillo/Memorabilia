using Memorabilia.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IMemorabiliaCommissionerRepository
    {
        Task Add(MemorabiliaCommissioner memorabiliaCommissioner, CancellationToken cancellationToken = default);

        Task Delete(MemorabiliaCommissioner memorabiliaCommissioner, CancellationToken cancellationToken = default);

        Task<MemorabiliaCommissioner> Get(int id);

        Task Update(MemorabiliaCommissioner memorabiliaCommissioner, CancellationToken cancellationToken = default);
    }
}
