namespace Memorabilia.Application.Features.Admin.Leagues;

public record SaveLeague(LeagueEditModel League) : ICommand
{
    public class Handler : CommandHandler<SaveLeague>
    {
        private readonly IDomainRepository<Entity.League> _leagueRepository;

        public Handler(IDomainRepository<Entity.League> leagueRepository)
        {
            _leagueRepository = leagueRepository;
        }

        protected override async Task Handle(SaveLeague request)
        {
            Entity.League league;

            if (request.League.IsNew)
            {
                league = new Entity.League(request.League.SportLeagueLevelId,
                                           request.League.Name,
                                           request.League.Abbreviation);

                await _leagueRepository.Add(league);

                return;
            }

            league = await _leagueRepository.Get(request.League.Id);

            if (request.League.IsDeleted)
            {
                await _leagueRepository.Delete(league);

                return;
            }

            league.Set(request.League.SportLeagueLevelId,
                       request.League.Name,
                       request.League.Abbreviation);

            await _leagueRepository.Update(league);
        }
    }
}
