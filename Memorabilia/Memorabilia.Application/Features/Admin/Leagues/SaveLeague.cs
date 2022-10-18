using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Leagues;

public record SaveLeague(SaveLeagueViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveLeague>
    {
        private readonly IDomainRepository<League> _leagueRepository;

        public Handler(IDomainRepository<League> leagueRepository)
        {
            _leagueRepository = leagueRepository;
        }

        protected override async Task Handle(SaveLeague request)
        {
            League league;

            if (request.ViewModel.IsNew)
            {
                league = new League(request.ViewModel.SportLeagueLevelId,
                                    request.ViewModel.Name,
                                    request.ViewModel.Abbreviation);

                await _leagueRepository.Add(league);

                return;
            }

            league = await _leagueRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _leagueRepository.Delete(league);

                return;
            }

            league.Set(request.ViewModel.SportLeagueLevelId,
                       request.ViewModel.Name,
                       request.ViewModel.Abbreviation);

            await _leagueRepository.Update(league);
        }
    }
}
