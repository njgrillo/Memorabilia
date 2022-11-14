using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.LeaguePresidents;

public record SaveLeaguePresident(SaveLeaguePresidentViewModel ViewModel) : ICommand
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
            LeaguePresident president;

            if (request.ViewModel.IsNew)
            {
                president = new LeaguePresident(request.ViewModel.SportLeagueLevelId,
                                          request.ViewModel.LeagueId,
                                          request.ViewModel.Person.Id,
                                          request.ViewModel.BeginYear,
                                          request.ViewModel.EndYear);

                await _presidentRepository.Add(president);

                return;
            }

            president = await _presidentRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _presidentRepository.Delete(president);

                return;
            }

            president.Set(request.ViewModel.BeginYear, request.ViewModel.EndYear);

            await _presidentRepository.Update(president);
        }
    }
}
