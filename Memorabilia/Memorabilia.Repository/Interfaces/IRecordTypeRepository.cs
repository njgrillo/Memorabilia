using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IRecordTypeRepository
    {
        Task Add(RecordType recordType, CancellationToken cancellationToken = default);

        Task Delete(RecordType recordType, CancellationToken cancellationToken = default);

        Task<RecordType> Get(int id);

        Task<IEnumerable<RecordType>> GetAll();

        Task Update(RecordType recordType, CancellationToken cancellationToken = default);
    }
}
