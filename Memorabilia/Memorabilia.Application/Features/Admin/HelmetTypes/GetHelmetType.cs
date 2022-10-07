using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.HelmetTypes;

public class GetHelmetType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<HelmetType> _helmetTypeRepository;

        public Handler(IDomainRepository<HelmetType> helmetTypeRepository)
        {
            _helmetTypeRepository = helmetTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _helmetTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
