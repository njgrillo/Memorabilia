using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Divisions;

public record SaveDivision(SaveDivisionViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveDivision>
    {
        private readonly IDomainRepository<Division> _divisionRepository;

        public Handler(IDomainRepository<Division> divisionRepository)
        {
            _divisionRepository = divisionRepository;
        }

        protected override async Task Handle(SaveDivision request)
        {
            Division division;

            if (request.ViewModel.IsNew)
            {
                division = new Division(request.ViewModel.ConferenceId > 0 ? request.ViewModel.ConferenceId : null,
                                        request.ViewModel.LeagueId > 0 ? request.ViewModel.LeagueId : null,
                                        request.ViewModel.Name,
                                        request.ViewModel.Abbreviation);

                await _divisionRepository.Add(division);

                return;
            }

            division = await _divisionRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _divisionRepository.Delete(division);

                return;
            }

            division.Set(request.ViewModel.ConferenceId,
                         request.ViewModel.LeagueId,
                         request.ViewModel.Name,
                         request.ViewModel.Abbreviation);

            await _divisionRepository.Update(division);
        }
    }
}
