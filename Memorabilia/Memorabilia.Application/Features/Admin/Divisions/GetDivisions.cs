using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Divisions;

public class GetDivisions
{
    public class Handler : QueryHandler<Query, DivisionsViewModel>
    {
        private readonly IDomainRepository<Division> _divisionRepository;

        public Handler(IDomainRepository<Division> divisionRepository)
        {
            _divisionRepository = divisionRepository;
        }

        protected override async Task<DivisionsViewModel> Handle(Query query)
        {
            return new DivisionsViewModel(await _divisionRepository.GetAll());
        }
    }

    public class Query : IQuery<DivisionsViewModel>
    {
        public Query() { }
    }
}
