namespace Memorabilia.Application.Features.Admin.AwardTypes;

public class GetAwardType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<Domain.Entities.AwardType> _awardTypeRepository;

        public Handler(IDomainRepository<Domain.Entities.AwardType> awardTypeRepository)
        {
            _awardTypeRepository = awardTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _awardTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
