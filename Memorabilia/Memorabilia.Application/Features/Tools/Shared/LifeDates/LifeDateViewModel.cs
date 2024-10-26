namespace Memorabilia.Application.Features.Tools.Shared.LifeDates;

public class LifeDateViewModel : PersonSportToolModel
{
    private readonly Entity.Person _person;

    public LifeDateViewModel(Entity.Person person, Constant.Sport sport)
    {
        _person = person;
        Sport = sport;
    }

    public DateTime? BirthDate
        => _person.BirthDate;

    public DateTime? DeathDate
        => _person.DeathDate;

    public override int PersonId
        => _person.Id;

    public override string PersonImageFileName
        => _person.ImageFileName;

    public override string PersonName
        => _person.ProfileName;
}
