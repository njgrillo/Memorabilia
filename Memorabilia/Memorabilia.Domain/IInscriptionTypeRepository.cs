using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IInscriptionTypeRepository
    {
        Task Add(Entities.InscriptionType inscriptionType, CancellationToken cancellationToken = default);

        Task Delete(Entities.InscriptionType inscriptionType, CancellationToken cancellationToken = default);

        Task<Entities.InscriptionType> Get(int id);

        Task<IEnumerable<Entities.InscriptionType>> GetAll();

        Task Update(Entities.InscriptionType inscriptionType, CancellationToken cancellationToken = default);
    }
}
