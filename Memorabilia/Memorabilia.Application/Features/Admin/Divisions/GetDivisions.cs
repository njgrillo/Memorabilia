namespace Memorabilia.Application.Features.Admin.Divisions
{
    public class GetDivisions
    {
        public class Handler : QueryHandler<Query, DivisionsViewModel>
        {
            private readonly IDivisionRepository _divisionRepository;

            public Handler(IDivisionRepository divisionRepository)
            {
                _divisionRepository = divisionRepository;
            }

            protected override async Task<DivisionsViewModel> Handle(Query query)
            {
                return new DivisionsViewModel(await _divisionRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<DivisionsViewModel>
        {
            public Query() { }
        }
    }
}
