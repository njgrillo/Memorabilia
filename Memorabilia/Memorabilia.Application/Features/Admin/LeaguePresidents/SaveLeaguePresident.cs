namespace Memorabilia.Application.Features.Admin.LeaguePresidents;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveLeaguePresident(LeaguePresidentEditModel LeaguePresident) : ICommand
{
    public class Handler(ILeaguePresidentRepository presidentRepository) 
        : CommandHandler<SaveLeaguePresident>
    {
        protected override async Task Handle(SaveLeaguePresident request)
        {
            Entity.LeaguePresident president;

            if (request.LeaguePresident.IsNew)
            {
                president = new Entity.LeaguePresident(request.LeaguePresident.SportLeagueLevelId,
                                                       request.LeaguePresident.LeagueId,
                                                       request.LeaguePresident.Person.Id,
                                                       request.LeaguePresident.BeginYear,
                                                       request.LeaguePresident.EndYear);

                await presidentRepository.Add(president);

                return;
            }

            president = await presidentRepository.Get(request.LeaguePresident.Id);

            if (request.LeaguePresident.IsDeleted)
            {
                await presidentRepository.Delete(president);

                return;
            }

            president.Set(request.LeaguePresident.BeginYear, 
                          request.LeaguePresident.EndYear);

            await presidentRepository.Update(president);
        }
    }
}
