namespace Memorabilia.Application.Features.Tools.Shared.Nicknames;

public class PersonNicknameViewModel : PersonSportToolModel
{
    private readonly Entity.Person _person;

    public PersonNicknameViewModel(Entity.Person person, Constant.Sport sport)
    {
        _person = person;
        Sport = sport;
    }

    public string[] Nicknames
        => _person.Nicknames
                  .Select(x => x.Nickname)
                  .OrderBy(x => x)  
                  .ToArray();

    public override int PersonId
        => _person.Id;

    public override string PersonImageFileName
        => _person.ImageFileName;

    public override string PersonName
        => _person.ProfileName;    
}
