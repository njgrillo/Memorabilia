namespace Memorabilia.Application.Features.Admin.SportLeagueLevels;

public record GetSportLeagueLevel(int Id) : IQuery<Entity.SportLeagueLevel>
{
    public class Handler(IDomainRepository<Entity.SportLeagueLevel> sportLeagueLevelRepository) 
        : QueryHandler<GetSportLeagueLevel, Entity.SportLeagueLevel>
    {
        protected override async Task<Entity.SportLeagueLevel> Handle(GetSportLeagueLevel query)
            => await sportLeagueLevelRepository.Get(query.Id);
    }
}
