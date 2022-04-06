using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IFigureTypeRepository
    {
        Task Add(FigureType figureType, CancellationToken cancellationToken = default);

        Task Delete(FigureType figureType, CancellationToken cancellationToken = default);

        Task<FigureType> Get(int id);

        Task<IEnumerable<FigureType>> GetAll();

        Task Update(FigureType figureType, CancellationToken cancellationToken = default);
    }
}
