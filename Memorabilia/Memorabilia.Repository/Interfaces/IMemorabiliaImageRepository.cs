namespace Memorabilia.Repository.Interfaces;

public interface IMemorabiliaImageRepository 
    : IDomainRepository<Entity.MemorabiliaImage>
{
    Task<Entity.MemorabiliaImage[]> GetAll(int memorabiliaId);
}
