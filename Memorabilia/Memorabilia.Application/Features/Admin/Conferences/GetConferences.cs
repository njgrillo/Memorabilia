namespace Memorabilia.Application.Features.Admin.Conferences
{
    public class GetConferences
    {
        public class Handler : QueryHandler<Query, ConferencesViewModel>
        {
            private readonly IConferenceRepository _conferenceRepository;

            public Handler(IConferenceRepository conferenceRepository)
            {
                _conferenceRepository = conferenceRepository;
            }

            protected override async Task<ConferencesViewModel> Handle(Query query)
            {
                return new ConferencesViewModel(await _conferenceRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<ConferencesViewModel>
        {
            public Query() { }
        }
    }
}
