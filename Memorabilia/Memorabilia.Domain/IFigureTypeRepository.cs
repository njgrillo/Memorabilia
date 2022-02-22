using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IFigureTypeRepository
    {
        Task Add(Entities.FigureType figureType, CancellationToken cancellationToken = default);

        Task Delete(Entities.FigureType figureType, CancellationToken cancellationToken = default);

        Task<Entities.FigureType> Get(int id);

        Task<IEnumerable<Entities.FigureType>> GetAll();

        Task Update(Entities.FigureType figureType, CancellationToken cancellationToken = default);
    }
}
