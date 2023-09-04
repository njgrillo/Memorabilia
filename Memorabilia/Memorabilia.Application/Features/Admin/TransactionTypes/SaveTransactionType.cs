namespace Memorabilia.Application.Features.Admin.TransactionTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SaveTransactionType(DomainEditModel TransactionType) : ICommand
{
    public class Handler : CommandHandler<SaveTransactionType>
    {
        private readonly IDomainRepository<Entity.TransactionType> _transactionTypeRepository;

        public Handler(IDomainRepository<Entity.TransactionType> transactionTypeRepository)
        {
            _transactionTypeRepository = transactionTypeRepository;
        }

        protected override async Task Handle(SaveTransactionType request)
        {
            Entity.TransactionType transactionType;

            if (request.TransactionType.IsNew)
            {
                transactionType = new Entity.TransactionType(request.TransactionType.Name,
                                                             request.TransactionType.Abbreviation);

                await _transactionTypeRepository.Add(transactionType);

                return;
            }

            transactionType = await _transactionTypeRepository.Get(request.TransactionType.Id);

            if (request.TransactionType.IsDeleted)
            {
                await _transactionTypeRepository.Delete(transactionType);

                return;
            }

            transactionType.Set(request.TransactionType.Name,
                                request.TransactionType.Abbreviation);

            await _transactionTypeRepository.Update(transactionType);
        }
    }
}
