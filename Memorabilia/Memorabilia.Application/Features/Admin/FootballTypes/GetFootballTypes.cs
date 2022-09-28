namespace Memorabilia.Application.Features.Admin.FootballTypes
{
    public class GetFootballTypes
    {
        public class Handler : QueryHandler<Query, FootballTypesViewModel>
        {
            private readonly IFootballTypeRepository _footballTypeRepository;

            public Handler(IFootballTypeRepository footballTypeRepository)
            {
                _footballTypeRepository = footballTypeRepository;
            }

            protected override async Task<FootballTypesViewModel> Handle(Query query)
            {
                return new FootballTypesViewModel(await _footballTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<FootballTypesViewModel> { }
    }
}
