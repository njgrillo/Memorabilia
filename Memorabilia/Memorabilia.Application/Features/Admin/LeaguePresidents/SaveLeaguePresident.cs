namespace Memorabilia.Application.Features.Admin.LeaguePresidents;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveLeaguePresident(LeaguePresidentEditModel LeaguePresident) : ICommand
{
    public class Handler : CommandHandler<SaveLeaguePresident>
    {
        private readonly ILeaguePresidentRepository _presidentRepository;

        public Handler(ILeaguePresidentRepository presidentRepository)
        {
            _presidentRepository = presidentRepository;
        }

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

                await _presidentRepository.Add(president);

                return;
            }

            president = await _presidentRepository.Get(request.LeaguePresident.Id);

            if (request.LeaguePresident.IsDeleted)
            {
                await _presidentRepository.Delete(president);

                return;
            }

            president.Set(request.LeaguePresident.BeginYear, 
                          request.LeaguePresident.EndYear);

            await _presidentRepository.Update(president);
        }
    }
}
