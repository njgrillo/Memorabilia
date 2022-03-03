using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IMemorabiliaFigureRepository
    {
        Task Add(Entities.MemorabiliaFigure memorabiliaFigureType, CancellationToken cancellationToken = default);

        Task Delete(Entities.MemorabiliaFigure memorabiliaFigureType, CancellationToken cancellationToken = default);

        Task<Entities.MemorabiliaFigure> Get(int id);

        Task Update(Entities.MemorabiliaFigure memorabiliaFigureType, CancellationToken cancellationToken = default);
    }
}
