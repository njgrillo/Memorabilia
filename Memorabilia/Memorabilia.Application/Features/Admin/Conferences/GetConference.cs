namespace Memorabilia.Application.Features.Admin.Conferences;

public record GetConference(int Id) : IQuery<Entity.Conference>
{
    public class Handler(IDomainRepository<Entity.Conference> conferenceRepository) 
        : QueryHandler<GetConference, Entity.Conference>
    {
        protected override async Task<Entity.Conference> Handle(GetConference query)
            => await conferenceRepository.Get(query.Id);
    }
}
