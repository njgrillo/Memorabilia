using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin;

public record SaveDomainItem<T>(SaveDomainViewModel ViewModel) : ICommand where T : DomainEntity
{
    public class Handler : CommandHandler<SaveDomainItem<T>>
    {
        private readonly IDomainRepository<T> _repository;

        public Handler(IDomainRepository<T> repository)
        {
            _repository = repository;
        }

        protected override async Task Handle(SaveDomainItem<T> request)
        {
            DomainEntity item;

            if (request.ViewModel.IsNew)
            {
                item = new DomainEntity(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _repository.Add((T)item);
                return;
            }

            item = await _repository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _repository.Delete((T)item);
                return;
            }

            item.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _repository.Update((T)item);
        }
    }
}
