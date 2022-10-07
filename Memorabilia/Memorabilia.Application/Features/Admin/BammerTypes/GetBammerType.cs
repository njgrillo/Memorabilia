using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BammerTypes;

public class GetBammerType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<BammerType> _bammerTypeRepository;

        public Handler(IDomainRepository<BammerType> bammerTypeRepository)
        {
            _bammerTypeRepository = bammerTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _bammerTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
