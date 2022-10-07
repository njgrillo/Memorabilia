using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.GameStyleTypes;

public class GetGameStyleType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<GameStyleType> _gameStyleTypeRepository;

        public Handler(IDomainRepository<GameStyleType> gameStyleTypeRepository)
        {
            _gameStyleTypeRepository = gameStyleTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _gameStyleTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
