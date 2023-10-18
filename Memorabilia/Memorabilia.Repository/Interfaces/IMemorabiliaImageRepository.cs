namespace Memorabilia.Repository.Interfaces;

public interface IMemorabiliaImageRepository 
    : IDomainRepository<MemorabiliaImage>
{
    Task<MemorabiliaImage[]> GetAll(int memorabiliaId);
}
