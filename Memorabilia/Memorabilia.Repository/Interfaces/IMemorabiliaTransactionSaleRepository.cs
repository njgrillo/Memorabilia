namespace Memorabilia.Repository.Interfaces;

public interface IMemorabiliaTransactionSaleRepository
    : IDomainRepository<MemorabiliaTransactionSale>
{
    Task<MemorabiliaTransactionSale[]> GetAll(int memorabiliaTransactionId);
}
