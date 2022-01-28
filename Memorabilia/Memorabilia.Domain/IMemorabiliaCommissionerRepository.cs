using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IMemorabiliaCommissionerRepository
    {
        Task Add(Entities.MemorabiliaCommissioner memorabiliaCommissioner, CancellationToken cancellationToken = default);

        Task Delete(Entities.MemorabiliaCommissioner memorabiliaCommissioner, CancellationToken cancellationToken = default);

        Task<Entities.MemorabiliaCommissioner> Get(int id);

        Task Update(Entities.MemorabiliaCommissioner memorabiliaCommissioner, CancellationToken cancellationToken = default);
    }
}
