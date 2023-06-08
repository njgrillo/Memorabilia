namespace Memorabilia.Application.Features.Tools.Shared.Awards;

public class AwardModel : PersonSportToolModel
{
    private readonly Entity.PersonAward _personAward;

    public AwardModel(Entity.PersonAward personAward, Constant.Sport sport)
    {
        _personAward = personAward;
        Sport = sport;
    }

    public override int PersonId 
        => _personAward.PersonId;

    public override string PersonImageFileName 
        => _personAward.Person.ImageFileName; 
    
    public override string PersonName 
        => _personAward.Person.DisplayName;

    public int Year 
        => _personAward.Year;
}
