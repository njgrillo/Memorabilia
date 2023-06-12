namespace Memorabilia.Application.Features.Admin.Divisions;

public record SaveDivision(DivisionEditModel Division) : ICommand
{
    public class Handler : CommandHandler<SaveDivision>
    {
        private readonly IDomainRepository<Entity.Division> _divisionRepository;

        public Handler(IDomainRepository<Entity.Division> divisionRepository)
        {
            _divisionRepository = divisionRepository;
        }

        protected override async Task Handle(SaveDivision request)
        {
            Entity.Division division;

            if (request.Division.IsNew)
            {
                division = new Entity.Division(request.Division.ConferenceId > 0 ? request.Division.ConferenceId : null,
                                               request.Division.LeagueId > 0 ? request.Division.LeagueId : null,
                                               request.Division.Name,
                                               request.Division.Abbreviation);

                await _divisionRepository.Add(division);

                return;
            }

            division = await _divisionRepository.Get(request.Division.Id);

            if (request.Division.IsDeleted)
            {
                await _divisionRepository.Delete(division);

                return;
            }

            division.Set(request.Division.ConferenceId,
                         request.Division.LeagueId,
                         request.Division.Name,
                         request.Division.Abbreviation);

            await _divisionRepository.Update(division);
        }
    }
}
