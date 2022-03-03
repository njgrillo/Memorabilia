using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IFigureSpecialtyTypeRepository
    {
        Task Add(Entities.FigureSpecialtyType figureSpecialityType, CancellationToken cancellationToken = default);

        Task Delete(Entities.FigureSpecialtyType figureSpecialityType, CancellationToken cancellationToken = default);

        Task<Entities.FigureSpecialtyType> Get(int id);

        Task<IEnumerable<Entities.FigureSpecialtyType>> GetAll();

        Task Update(Entities.FigureSpecialtyType figureSpecialityType, CancellationToken cancellationToken = default);
    }
}
