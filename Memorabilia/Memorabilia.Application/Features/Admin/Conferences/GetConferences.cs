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
            return new ConferencesViewModel(await _conferenceRepository.GetAll());
        }
    }
}
