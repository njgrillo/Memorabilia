namespace Memorabilia.Application.Features.Admin.People.Management.HallOfFames;

public class InternationalHallOfFameViewModel
{
    private readonly Entity.InternationalHallOfFame _hallOfFame;

    public InternationalHallOfFameViewModel() { }

    public InternationalHallOfFameViewModel(Entity.InternationalHallOfFame hallOfFame)
    {
        _hallOfFame = hallOfFame;
    }

    public Constant.InternationalHallOfFameType Franchise
        => Constant.InternationalHallOfFameType.Find(_hallOfFame.InternationalHallOfFameTypeId);

    public string InternationalHallOfFameTypeName
        => Franchise?.Name;

    public int Id
        => _hallOfFame.Id;

    public int PersonId
        => _hallOfFame.PersonId;

    public int? Year
        => _hallOfFame.InductionYear;
}
