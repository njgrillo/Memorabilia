namespace Memorabilia.Domain
{
    public interface IItemTypeRepository
    {
        Task Add(Entities.ItemType itemType, CancellationToken cancellationToken = default);

        Task Delete(Entities.ItemType itemType, CancellationToken cancellationToken = default);

        Task<Entities.ItemType> Get(int id);

        Task<IEnumerable<Entities.ItemType>> GetAll();

        Task Update(Entities.ItemType itemType, CancellationToken cancellationToken = default);
    }
}
