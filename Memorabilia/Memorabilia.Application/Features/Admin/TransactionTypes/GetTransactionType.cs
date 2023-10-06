namespace Memorabilia.Application.Features.Admin.TransactionTypes;

public record GetTransactionType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetTransactionType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.TransactionType> _repository;

        public Handler(IDomainRepository<Entity.TransactionType> repository)
        {
            _repository = repository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetTransactionType query)
            => await _repository.Get(query.Id);
    }
}
