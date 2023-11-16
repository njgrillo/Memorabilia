namespace Memorabilia.Application.Features.Admin.Divisions;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveDivision(DivisionEditModel Division) : ICommand
{
    public class Handler(IDomainRepository<Entity.Division> divisionRepository) 
        : CommandHandler<SaveDivision>
    {
        protected override async Task Handle(SaveDivision request)
        {
            Entity.Division division;

            if (request.Division.IsNew)
            {
                division = new Entity.Division(request.Division.ConferenceId > 0 ? request.Division.ConferenceId : null,
                                               request.Division.LeagueId > 0 ? request.Division.LeagueId : null,
                                               request.Division.Name,
                                               request.Division.Abbreviation);

                await divisionRepository.Add(division);

                return;
            }

            division = await divisionRepository.Get(request.Division.Id);

            if (request.Division.IsDeleted)
            {
                await divisionRepository.Delete(division);

                return;
            }

            division.Set(request.Division.ConferenceId,
                         request.Division.LeagueId,
                         request.Division.Name,
                         request.Division.Abbreviation);

            await divisionRepository.Update(division);
        }
    }
}
