using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Divisions;

public class GetDivision
{
    public class Handler : QueryHandler<Query, DivisionViewModel>
    {
        private readonly IDomainRepository<Division> _divisionRepository;

        public Handler(IDomainRepository<Division> divisionRepository)
        {
            _divisionRepository = divisionRepository;
        }

        protected override async Task<DivisionViewModel> Handle(Query query)
        {
            return new DivisionViewModel(await _divisionRepository.Get(query.Id));
        }
    }

    public class Query : IQuery<DivisionViewModel>
    {
        public Query(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
