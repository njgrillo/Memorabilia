namespace Memorabilia.Application.Features.Tools.Shared.Nicknames;

public class PersonNicknamesViewModel : Model
{
    public PersonNicknamesViewModel() { }

    public PersonNicknamesViewModel(
        Entity.Person[] persons, 
        Constant.Sport sport,
        PageInfoResult pageInfo)
    {
        PageInfo = pageInfo;
        Persons = persons.Select(person => new PersonNicknameViewModel(person, sport));        
        Sport = sport;
    }

    public IEnumerable<PersonNicknameViewModel> Persons { get; set; }
        = [];

    public Constant.Sport Sport { get; set; }
}
