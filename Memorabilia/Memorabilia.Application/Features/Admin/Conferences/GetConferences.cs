namespace Memorabilia.Application.Features.Admin.Conferences;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetConferences() : IQuery<Entity.Conference[]>
{
    public class Handler : QueryHandler<GetConferences, Entity.Conference[]>
    {
        private readonly IDomainRepository<Entity.Conference> _conferenceRepository;

        public Handler(IDomainRepository<Entity.Conference> conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }

        protected override async Task<Entity.Conference[]> Handle(GetConferences query)
            => await _conferenceRepository.GetAll();
    }
}
