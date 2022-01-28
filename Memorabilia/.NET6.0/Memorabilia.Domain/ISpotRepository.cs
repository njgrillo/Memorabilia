namespace Memorabilia.Domain
{
    public interface ISpotRepository
    {
        Task Add(Entities.Spot spot, CancellationToken cancellationToken = default);

        Task Delete(Entities.Spot spot, CancellationToken cancellationToken = default);

        Task<Entities.Spot> Get(int id);

        Task<IEnumerable<Entities.Spot>> GetAll();

        Task Update(Entities.Spot spot, CancellationToken cancellationToken = default);
    }
}
