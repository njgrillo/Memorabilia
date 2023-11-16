﻿namespace Memorabilia.Application.Features.Admin.TransactionTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveTransactionType(DomainEditModel TransactionType) : ICommand
{
    public class Handler(IDomainRepository<Entity.TransactionType> transactionTypeRepository) 
        : CommandHandler<SaveTransactionType>
    {
        protected override async Task Handle(SaveTransactionType request)
        {
            Entity.TransactionType transactionType;

            if (request.TransactionType.IsNew)
            {
                transactionType = new Entity.TransactionType(request.TransactionType.Name,
                                                             request.TransactionType.Abbreviation);

                await transactionTypeRepository.Add(transactionType);

                return;
            }

            transactionType = await transactionTypeRepository.Get(request.TransactionType.Id);

            if (request.TransactionType.IsDeleted)
            {
                await transactionTypeRepository.Delete(transactionType);

                return;
            }

            transactionType.Set(request.TransactionType.Name,
                                request.TransactionType.Abbreviation);

            await transactionTypeRepository.Update(transactionType);
        }
    }
}
