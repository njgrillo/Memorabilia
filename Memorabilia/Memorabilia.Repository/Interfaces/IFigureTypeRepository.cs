using Memorabilia.Domain.Entities;

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
