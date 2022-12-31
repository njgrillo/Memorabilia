using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.Awards;

public class AwardViewModel : PersonSportToolViewModel
{
    private readonly PersonAward _personAward;

    public AwardViewModel(PersonAward personAward, Domain.Constants.Sport sport)
    {
        _personAward = personAward;
        Sport = sport;
    }

    public override int PersonId => _personAward.PersonId;

    public override string PersonImageFileName => _personAward.Person.ImageFileName; 
    
    public override string PersonName => _personAward.Person.DisplayName;

    public string Year => _personAward.Year.ToString();
}
