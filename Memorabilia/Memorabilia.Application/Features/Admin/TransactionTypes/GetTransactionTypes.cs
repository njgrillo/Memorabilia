namespace Memorabilia.Application.Features.Admin.TransactionTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetTransactionTypes() : IQuery<Entity.TransactionType[]>
{
    public class Handler : QueryHandler<GetTransactionTypes, Entity.TransactionType[]>
    {
        private readonly IDomainRepository<Entity.TransactionType> _repository;

        public Handler(IDomainRepository<Entity.TransactionType> repository)
        {
            _repository = repository;
        }

        protected override async Task<Entity.TransactionType[]> Handle(GetTransactionTypes query)
            => await _repository.GetAll();
    }
}
