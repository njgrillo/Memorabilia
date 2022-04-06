using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface ISizeRepository
    {
        Task Add(Size size, CancellationToken cancellationToken = default);

        Task Delete(Size size, CancellationToken cancellationToken = default);

        Task<Size> Get(int id);

        Task<IEnumerable<Size>> GetAll();

        Task Update(Size size, CancellationToken cancellationToken = default);
    }
}
