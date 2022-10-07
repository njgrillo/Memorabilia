using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Conferences;

public class GetConference
{
    public class Handler : QueryHandler<Query, ConferenceViewModel>
    {
        private readonly IDomainRepository<Conference> _conferenceRepository;

        public Handler(IDomainRepository<Conference> conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }

        protected override async Task<ConferenceViewModel> Handle(Query query)
        {
            return new ConferenceViewModel(await _conferenceRepository.Get(query.Id));
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
