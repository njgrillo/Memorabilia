using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Conferences;

public class GetConferences
{
    public class Handler : QueryHandler<Query, ConferencesViewModel>
    {
        private readonly IDomainRepository<Conference> _conferenceRepository;

        public Handler(IDomainRepository<Conference> conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }

        protected override async Task<ConferencesViewModel> Handle(Query query)
        {
            return new ConferencesViewModel(await _conferenceRepository.GetAll());
        }
    }

    public class Query : IQuery<ConferencesViewModel>
    {
        public Query() { }
    }
}
