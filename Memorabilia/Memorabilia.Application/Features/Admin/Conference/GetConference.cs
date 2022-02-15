using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Conference
{
    public class GetConference
    {
        public class Handler : QueryHandler<Query, ConferenceViewModel>
        {
            private readonly IConferenceRepository _conferenceRepository;

            public Handler(IConferenceRepository conferenceRepository)
            {
                _conferenceRepository = conferenceRepository;
            }

            protected override async Task<ConferenceViewModel> Handle(Query query)
            {
                var conference = await _conferenceRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new ConferenceViewModel(conference);

                return viewModel;
            }
        }

        public class Query : IQuery<ConferenceViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
