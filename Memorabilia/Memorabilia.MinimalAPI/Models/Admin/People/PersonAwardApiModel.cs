namespace Memorabilia.MinimalAPI.Models.Admin.People;

public class PersonAwardApiModel
{
    private readonly Entity.PersonAward _personAward;

    public PersonAwardApiModel(Entity.PersonAward personAward)
    {
        _personAward = personAward;
    }

    public string Name
        => Constant.AwardType.Find(_personAward.AwardTypeId).Name;

    public int Year
        => _personAward.Year;
}
