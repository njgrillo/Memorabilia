using Memorabilia.Repository;

namespace Memorabilia.Application.Features.Admin;

public record GetDomainItem<T>(int Id) : IQuery<DomainModel> where T : Entity.DomainEntity
{
    public abstract class Handler : QueryHandler<GetDomainItem<T>, DomainModel>
    {
        protected readonly IDomainRepository<T> _repository;

        public Handler(IServiceProvider serviceProvider)
        {
            var type = typeof(T);
            var validatorWrapper = typeof(DomainRepository<>).MakeGenericType(type);

            _repository = (IDomainRepository<T>)serviceProvider.GetService(validatorWrapper);
        }

        protected override async Task<DomainModel> Handle(GetDomainItem<T> query)
        {
            return new DomainModel(await _repository.Get(query.Id));
        }
    }
}

