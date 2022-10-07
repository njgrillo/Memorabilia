using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AccomplishmentTypes;

public class GetAccomplishmentType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<AccomplishmentType> _accomplishmentTypeRepository;

        public Handler(IDomainRepository<AccomplishmentType> accomplishmentTypeRepository)
        {
            _accomplishmentTypeRepository = accomplishmentTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _accomplishmentTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
