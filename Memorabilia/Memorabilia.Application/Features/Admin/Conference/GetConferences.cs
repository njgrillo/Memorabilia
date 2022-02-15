using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Conference
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
                var conferences = await _conferenceRepository.GetAll().ConfigureAwait(false);

                var viewModel = new ConferencesViewModel(conferences);

                return viewModel;
            }
        }

        public class Query : IQuery<ConferencesViewModel>
        {
            public Query() { }
        }
    }
}
