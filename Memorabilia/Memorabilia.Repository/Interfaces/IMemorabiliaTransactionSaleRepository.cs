namespace Memorabilia.Repository.Interfaces;

public interface IMemorabiliaTransactionSaleRepository
    : IDomainRepository<Entity.MemorabiliaTransactionSale>
{
    Task<Entity.MemorabiliaTransactionSale[]> GetAll(int memorabiliaTransactionId);
}
