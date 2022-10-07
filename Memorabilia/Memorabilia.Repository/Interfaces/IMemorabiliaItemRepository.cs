namespace Memorabilia.Repository.Interfaces;

public interface IMemorabiliaItemRepository : IDomainRepository<Domain.Entities.Memorabilia>
{
    Task<IEnumerable<Domain.Entities.Memorabilia>> GetAll(int userId);

    Task<IEnumerable<Domain.Entities.Memorabilia>> GetAllUnsigned(int userId);
}
