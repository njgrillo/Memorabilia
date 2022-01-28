namespace Memorabilia.Domain
{
    public interface IJerseyTypeRepository
    {
        Task Add(Entities.JerseyType jerseyType, CancellationToken cancellationToken = default);

        Task Delete(Entities.JerseyType jerseyType, CancellationToken cancellationToken = default);

        Task<Entities.JerseyType> Get(int id);

        Task<IEnumerable<Entities.JerseyType>> GetAll();

        Task Update(Entities.JerseyType jerseyType, CancellationToken cancellationToken = default);
    }
}
