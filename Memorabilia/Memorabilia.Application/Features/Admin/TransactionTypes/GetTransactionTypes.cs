namespace Memorabilia.Application.Features.Admin.TransactionTypes;

public record GetTransactionTypes() : IQuery<Entity.TransactionType[]>
{
    public class Handler(IDomainRepository<Entity.TransactionType> repository) 
        : QueryHandler<GetTransactionTypes, Entity.TransactionType[]>
    {
        protected override async Task<Entity.TransactionType[]> Handle(GetTransactionTypes query)
            => await repository.GetAll();
    }
}
