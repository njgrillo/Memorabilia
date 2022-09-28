using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IWritingInstrumentRepository
    {
        Task Add(WritingInstrument writingInstrument, CancellationToken cancellationToken = default);

        Task Delete(WritingInstrument writingInstrument, CancellationToken cancellationToken = default);

        Task<WritingInstrument> Get(int id);

        Task<IEnumerable<WritingInstrument>> GetAll();

        Task Update(WritingInstrument writingInstrument, CancellationToken cancellationToken = default);
    }
}
