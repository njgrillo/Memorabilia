namespace Memorabilia.MinimalAPI.Models.Admin.People;

public class PersonAccomplishmentApiModel
{
    private readonly Entity.PersonAccomplishment _personAccomplishment;

    public PersonAccomplishmentApiModel(Entity.PersonAccomplishment personAccomplishment)
    {
        _personAccomplishment = personAccomplishment;
    }

    public string? Date
        => _personAccomplishment.Date?.ToShortDateString();
            
    public string Name
        => Constant.AccomplishmentType.Find(_personAccomplishment.AccomplishmentTypeId).Name;

    public int? Year
        => _personAccomplishment.Year.HasValue
        ? _personAccomplishment.Year
        : _personAccomplishment.Date.HasValue
            ? _personAccomplishment.Date.Value.Year
            : null;
}
