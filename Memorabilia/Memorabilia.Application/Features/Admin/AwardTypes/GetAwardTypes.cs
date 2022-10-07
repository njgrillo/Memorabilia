namespace Memorabilia.Application.Features.Admin.AwardTypes;

public class GetAwardTypes
{
    public class Handler : QueryHandler<Query, AwardTypesViewModel>
    {
        private readonly IDomainRepository<Domain.Entities.AwardType> _awardTypeRepository;

        public Handler(IDomainRepository<Domain.Entities.AwardType> awardTypeRepository)
        {
            _awardTypeRepository = awardTypeRepository;
        }

        protected override async Task<AwardTypesViewModel> Handle(Query query)
        {
            return new AwardTypesViewModel(await _awardTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<AwardTypesViewModel> { }
}
