namespace Memorabilia.Domain
{
    public interface IBrandRepository
    {
        Task Add(Entities.Brand brand, CancellationToken cancellationToken = default);

        Task Delete(Entities.Brand brand, CancellationToken cancellationToken = default);

        Task<Entities.Brand> Get(int id);

        Task<IEnumerable<Entities.Brand>> GetAll();

        Task Update(Entities.Brand brand, CancellationToken cancellationToken = default);
    }
}
