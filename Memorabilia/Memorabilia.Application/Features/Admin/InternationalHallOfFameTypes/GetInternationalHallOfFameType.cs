using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.InternationalHallOfFameTypes;

public class GetInternationalHallOfFameType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<InternationalHallOfFameType> _internationalHallOfFameTypeRepository;

        public Handler(IDomainRepository<InternationalHallOfFameType> internationalHallOfFameTypeRepository)
        {
            _internationalHallOfFameTypeRepository = internationalHallOfFameTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _internationalHallOfFameTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
