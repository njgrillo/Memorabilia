using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Conferences;

public record GetConferences() : IQuery<ConferencesViewModel>
{
    public class Handler : QueryHandler<GetConferences, ConferencesViewModel>
    {
        private readonly IDomainRepository<Conference> _conferenceRepository;

        public Handler(IDomainRepository<Conference> conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }

        protected override async Task<ConferencesViewModel> Handle(GetConferences query)
        {
            var conferences = (await _conferenceRepository.GetAll())
                                    .OrderBy(conference => conference.SportLeagueLevelName)
                                    .ThenBy(conference => conference.Name);

            return new ConferencesViewModel(conferences);
        }
    }
}
