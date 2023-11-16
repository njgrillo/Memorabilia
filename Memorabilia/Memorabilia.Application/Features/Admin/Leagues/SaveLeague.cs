namespace Memorabilia.Application.Features.Admin.Leagues;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveLeague(LeagueEditModel League) : ICommand
{
    public class Handler(IDomainRepository<Entity.League> leagueRepository) 
        : CommandHandler<SaveLeague>
    {
        protected override async Task Handle(SaveLeague request)
        {
            Entity.League league;

            if (request.League.IsNew)
            {
                league = new Entity.League(request.League.SportLeagueLevelId,
                                           request.League.Name,
                                           request.League.Abbreviation);

                await leagueRepository.Add(league);

                return;
            }

            league = await leagueRepository.Get(request.League.Id);

            if (request.League.IsDeleted)
            {
                await leagueRepository.Delete(league);

                return;
            }

            league.Set(request.League.SportLeagueLevelId,
                       request.League.Name,
                       request.League.Abbreviation);

            await leagueRepository.Update(league);
        }
    }
}
