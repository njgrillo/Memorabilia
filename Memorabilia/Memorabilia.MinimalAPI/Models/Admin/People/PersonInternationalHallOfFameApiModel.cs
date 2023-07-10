namespace Memorabilia.MinimalAPI.Models.Admin.People;

public class PersonInternationalHallOfFameApiModel
{
    private readonly Entity.InternationalHallOfFame _internationalHallOfFame;

    public PersonInternationalHallOfFameApiModel(Entity.InternationalHallOfFame internationalHallOfFame)
    {
        _internationalHallOfFame = internationalHallOfFame;
    }

    public string Type
        => Constant.InternationalHallOfFameType.Find(_internationalHallOfFame.InternationalHallOfFameTypeId).Name;

    public int? Year
        => _internationalHallOfFame.InductionYear;
}
