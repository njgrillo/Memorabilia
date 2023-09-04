namespace Memorabilia.Application.Features.Admin.Conferences;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetConference(int Id) : IQuery<Entity.Conference>
{
    public class Handler : QueryHandler<GetConference, Entity.Conference>
    {
        private readonly IDomainRepository<Entity.Conference> _conferenceRepository;

        public Handler(IDomainRepository<Entity.Conference> conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }

        protected override async Task<Entity.Conference> Handle(GetConference query)
            => await _conferenceRepository.Get(query.Id);
    }
}
