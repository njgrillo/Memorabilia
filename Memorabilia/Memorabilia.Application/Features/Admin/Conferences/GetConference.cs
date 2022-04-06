using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Conferences
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
                return new ConferenceViewModel(await _conferenceRepository.Get(query.Id).ConfigureAwait(false));
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
