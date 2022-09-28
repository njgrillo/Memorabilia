namespace Memorabilia.Repository.Interfaces
{
    public interface IMemorabiliaRepository
    {
        Task Add(Domain.Entities.Memorabilia memorabilia, CancellationToken cancellationToken = default);

        Task Delete(Domain.Entities.Memorabilia memorabilia, CancellationToken cancellationToken = default);

        Task<Domain.Entities.Memorabilia> Get(int id);

        Task<IEnumerable<Domain.Entities.Memorabilia>> GetAll(int userId);

        Task<IEnumerable<Domain.Entities.Memorabilia>> GetAllUnsigned(int userId);

        Task Update(Domain.Entities.Memorabilia memorabilia, CancellationToken cancellationToken = default);
    }
}
