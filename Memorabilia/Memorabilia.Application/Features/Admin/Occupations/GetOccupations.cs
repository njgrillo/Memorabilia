namespace Memorabilia.Application.Features.Admin.Occupations
{
    public class GetOccupations
    {
        public class Handler : QueryHandler<Query, OccupationsViewModel>
        {
            private readonly IOccupationRepository _occupationRepository;

            public Handler(IOccupationRepository occupationRepository)
            {
                _occupationRepository = occupationRepository;
            }

            protected override async Task<OccupationsViewModel> Handle(Query query)
            {
                return new OccupationsViewModel(await _occupationRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<OccupationsViewModel> { }
    }
}
