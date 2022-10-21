using Memorabilia.Repository;

namespace Memorabilia.Application.Features.Admin;

public record GetDomainItem<T>(int Id) : IQuery<DomainViewModel> where T : Domain.Entities.DomainEntity
{
    public abstract class Handler : QueryHandler<GetDomainItem<T>, DomainViewModel>
    {
        protected readonly IDomainRepository<T> _repository;

        public Handler(IServiceProvider serviceProvider)
        {
            //_repository = repository;

            var type = typeof(T);
            var validatorWrapper = typeof(DomainRepository<>).MakeGenericType(type);
            _repository = (IDomainRepository<T>)serviceProvider.GetService(validatorWrapper);
        }

        protected override async Task<DomainViewModel> Handle(GetDomainItem<T> query)
        {
            return new DomainViewModel(await _repository.Get(query.Id));
        }
    }
}

