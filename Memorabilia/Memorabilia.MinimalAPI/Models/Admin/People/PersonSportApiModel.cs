namespace Memorabilia.MinimalAPI.Models.Admin.People;

public class PersonSportApiModel
{
    private readonly Entity.PersonSport _personSport;

    public PersonSportApiModel(Entity.PersonSport personSport)
    {
        _personSport = personSport;
    }

    public string Sport
        => Constant.Sport.Find(_personSport.SportId).Name;

    public string SportType
        => _personSport.IsPrimary
        ? "Primary"
        : "Secondary";
}
