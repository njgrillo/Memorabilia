using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IWritingInstrumentRepository
    {
        Task Add(Entities.WritingInstrument writingInstrument, CancellationToken cancellationToken = default);

        Task Delete(Entities.WritingInstrument writingInstrument, CancellationToken cancellationToken = default);

        Task<Entities.WritingInstrument> Get(int id);

        Task<IEnumerable<Entities.WritingInstrument>> GetAll();

        Task Update(Entities.WritingInstrument writingInstrument, CancellationToken cancellationToken = default);
    }
}
