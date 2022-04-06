using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IMemorabiliaPersonRepository
    {
        Task Add(MemorabiliaPerson memorabiliaPerson, CancellationToken cancellationToken = default);

        Task Delete(IEnumerable<MemorabiliaPerson> memorabiliaPeople, CancellationToken cancellationToken = default);

        Task<MemorabiliaPerson> Get(int id);

        Task Update(MemorabiliaPerson memorabiliaPerson, CancellationToken cancellationToken = default);
    }
}
