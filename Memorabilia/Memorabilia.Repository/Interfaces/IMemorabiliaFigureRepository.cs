using Memorabilia.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IMemorabiliaFigureRepository
    {
        Task Add(MemorabiliaFigure memorabiliaFigureType, CancellationToken cancellationToken = default);

        Task Delete(MemorabiliaFigure memorabiliaFigureType, CancellationToken cancellationToken = default);

        Task<MemorabiliaFigure> Get(int id);

        Task Update(MemorabiliaFigure memorabiliaFigureType, CancellationToken cancellationToken = default);
    }
}
