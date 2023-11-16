namespace Memorabilia.Application.Features.Admin.Conferences;

public record GetConferences() : IQuery<Entity.Conference[]>
{
    public class Handler(IDomainRepository<Entity.Conference> conferenceRepository) 
        : QueryHandler<GetConferences, Entity.Conference[]>
    {
        protected override async Task<Entity.Conference[]> Handle(GetConferences query)
            => await conferenceRepository.GetAll();
    }
}
