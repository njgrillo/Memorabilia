namespace Memorabilia.Application.Features.Transaction;

public record GetMemorabiliaTransactionSales(int MemorabiliaTransactionId)
    : IQuery<Entity.MemorabiliaTransactionSale[]>
{
    public class Handler : QueryHandler<GetMemorabiliaTransactionSales, Entity.MemorabiliaTransactionSale[]>
    {
        private readonly IMemorabiliaTransactionSaleRepository _memorabiliaTransactionSaleRepository;

        public Handler(IMemorabiliaTransactionSaleRepository memorabiliaTransactionSaleRepository)
        {
            _memorabiliaTransactionSaleRepository = memorabiliaTransactionSaleRepository;
        }

        protected override async Task<Entity.MemorabiliaTransactionSale[]> Handle(GetMemorabiliaTransactionSales query)
            => await _memorabiliaTransactionSaleRepository.GetAll(query.MemorabiliaTransactionId);
    }
}
