using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Conferences;

public record GetConference(int Id) : IQuery<ConferenceViewModel>
{
    public class Handler : QueryHandler<GetConference, ConferenceViewModel>
    {
        private readonly IDomainRepository<Conference> _conferenceRepository;

        public Handler(IDomainRepository<Conference> conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }

        protected override async Task<ConferenceViewModel> Handle(GetConference query)
        {
            return new ConferenceViewModel(await _conferenceRepository.Get(query.Id));
        }
    }
}
