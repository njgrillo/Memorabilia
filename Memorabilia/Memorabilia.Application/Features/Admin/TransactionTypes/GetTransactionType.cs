namespace Memorabilia.Application.Features.Admin.TransactionTypes;

public record GetTransactionType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.TransactionType> repository) 
        : QueryHandler<GetTransactionType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetTransactionType query)
            => await repository.Get(query.Id);
    }
}
