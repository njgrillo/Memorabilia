using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BaseballTypes;

public class GetBaseballTypes
{
    public class Handler : QueryHandler<Query, BaseballTypesViewModel>
    {
        private readonly IDomainRepository<BaseballType> _baseballTypeRepository;

        public Handler(IDomainRepository<BaseballType> baseballTypeRepository)
        {
            _baseballTypeRepository = baseballTypeRepository;
        }

        protected override async Task<BaseballTypesViewModel> Handle(Query query)
        {
            return new BaseballTypesViewModel(await _baseballTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<BaseballTypesViewModel> { }
}
