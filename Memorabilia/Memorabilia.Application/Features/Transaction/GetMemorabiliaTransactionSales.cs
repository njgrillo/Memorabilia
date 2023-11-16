namespace Memorabilia.Application.Features.Transaction;

public record GetMemorabiliaTransactionSales(int MemorabiliaTransactionId)
    : IQuery<Entity.MemorabiliaTransactionSale[]>
{
    public class Handler(IMemorabiliaTransactionSaleRepository memorabiliaTransactionSaleRepository) 
        : QueryHandler<GetMemorabiliaTransactionSales, Entity.MemorabiliaTransactionSale[]>
    {
        protected override async Task<Entity.MemorabiliaTransactionSale[]> Handle(GetMemorabiliaTransactionSales query)
            => await memorabiliaTransactionSaleRepository.GetAll(query.MemorabiliaTransactionId);
    }
}
