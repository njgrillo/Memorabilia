using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.Accomplishments;

public class AccomplishmentViewModel : PersonSportToolViewModel
{
    private readonly PersonAccomplishment _personAccomplishment;

    public AccomplishmentViewModel(PersonAccomplishment personAccomplishment, Domain.Constants.Sport sport)
    {
        _personAccomplishment = personAccomplishment;
        Sport = sport;
    }

    public string Date => _personAccomplishment.Date?.ToString("MM/dd/yyyy");

    public override int PersonId => _personAccomplishment.PersonId;

    public override string PersonImageFileName => _personAccomplishment.Person.ImageFileName;

    public override string PersonName => _personAccomplishment.Person.DisplayName;

    public string Year => _personAccomplishment?.Year.ToString();
}
