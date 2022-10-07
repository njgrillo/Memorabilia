using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.LevelTypes;

public class GetLevelType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<LevelType> _levelTypeRepository;

        public Handler(IDomainRepository<LevelType> levelTypeRepository)
        {
            _levelTypeRepository = levelTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _levelTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
